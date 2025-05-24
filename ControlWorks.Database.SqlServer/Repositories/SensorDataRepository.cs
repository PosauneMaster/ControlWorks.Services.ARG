using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using ControlWorks.Database.SqlServer.InternalEntities;

namespace ControlWorks.Database.SqlServer.Repositories
{
    public class SensorDataRepository
    {
        private readonly string _connectionString = Common.ConfigurationProvider.ConnectionString;

        public async Task Insert(int coilDataId, IEnumerable<SensorDataInternal> sensorData)
        {
            var sensorDataTable = MapToDataTable(coilDataId, sensorData);

            var insertCommand = "[dbo].[SensorData_Insert] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = insertCommand;
                        command.CommandType = CommandType.StoredProcedure;

                        var tableParameter = command.Parameters.AddWithValue("@sensorDataTable", sensorDataTable);
                        tableParameter.SqlDbType = SqlDbType.Structured;

                        await command.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private DataTable MapToDataTable(int coilDataId, IEnumerable<SensorDataInternal> sensorData)
        {
            var dt = new DataTable();
            dt.Columns.Add("CoilDataId", typeof(int));
            dt.Columns.Add("SensorNumber", typeof(int));
            dt.Columns.Add("Position", typeof(decimal));
            dt.Columns.Add("SensorData0", typeof(decimal));
            dt.Columns.Add("SensorData1", typeof(decimal));
            dt.Columns.Add("SensorData2", typeof(decimal));
            dt.Columns.Add("SensorData3", typeof(decimal));
            dt.Columns.Add("SensorData4", typeof(decimal));

            foreach (var sensor in sensorData)
            {
                var row = dt.NewRow();
                row["CoilDataId"] = coilDataId;
                row["SensorNumber"] = sensor.SensorNumber;
                row["Position"] = sensor.Position;
                row["SensorData0"] = sensor.SensorData0;
                row["SensorData1"] = sensor.SensorData1;
                row["SensorData2"] = sensor.SensorData2;
                row["SensorData3"] = sensor.SensorData3;
                row["SensorData4"] = sensor.SensorData4;

                dt.Rows.Add(row);
            }

            return dt;

        }
    }
}
