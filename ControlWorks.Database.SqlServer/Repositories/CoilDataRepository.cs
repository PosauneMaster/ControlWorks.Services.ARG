using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using ControlWorks.Database.SqlServer.InternalEntities;

namespace ControlWorks.Database.SqlServer.Repositories
{
    public class CoilDataRepository
    {
        private readonly string _connectionString = Common.ConfigurationProvider.ConnectionString;

        public async Task<int> Insert(CoilDataInternal coilData, string ipAddress, string cpuName)
        {
            var insertCommand = "[dbo].[CoilData_Insert]";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = insertCommand;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@materialType", coilData.MaterialType);
                        command.Parameters.AddWithValue("@materialThickness", coilData.MaterialThickness);
                        command.Parameters.AddWithValue("@originalSqYards", coilData.OriginalSqYards);
                        command.Parameters.AddWithValue("@batchNumber", coilData.BatchNumber);
                        command.Parameters.AddWithValue("@changeNumber", coilData.BatchNumber);
                        command.Parameters.AddWithValue("@extrusionDate", coilData.ExtrusionDate);
                        command.Parameters.AddWithValue("@rollSnNumber", coilData.RollNumber);
                        command.Parameters.AddWithValue("@coilNumber", coilData.CoilNumber);
                        command.Parameters.AddWithValue("@coilWidth", coilData.CoilWidth);
                        command.Parameters.AddWithValue("@tolerancePlus", coilData.TolerancePlus);
                        command.Parameters.AddWithValue("@toleranceMinus", coilData.ToleranceMinus);
                        command.Parameters.AddWithValue("@inspector", coilData.Inspector);
                        command.Parameters.AddWithValue("@inspectionDateTime", coilData.InspectionDateTime);
                        command.Parameters.AddWithValue("@calibrationDate", coilData.CalibrationDate);
                        command.Parameters.AddWithValue("@generatedMaterialType", coilData.GeneratedMaterialType);
                        command.Parameters.AddWithValue("@ovenPos", coilData.OvenPos);
                        command.Parameters.AddWithValue("@batchRunTimestamp", coilData.BatchRunTimestamp);
                        command.Parameters.AddWithValue("@machineNumber", coilData.MachineNumber);
                        command.Parameters.AddWithValue("@coilSnNumber", coilData.Coil_SN_Number);
                        command.Parameters.AddWithValue("@labInspector", coilData.LabInspector);
                        command.Parameters.AddWithValue("@rollNumber", coilData.RollNumber);
                        command.Parameters.AddWithValue("@labInspectDate", coilData.LabInspectDate);
                        command.Parameters.AddWithValue("@ipAddress", coilData);
                        command.Parameters.AddWithValue("@cpuName", cpuName);

                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }

            return 0;
        }
    }
}