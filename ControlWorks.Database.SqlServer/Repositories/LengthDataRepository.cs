using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer.Repositories
{
    public class LengthDataRepository : Repository<LengthData>
    {
        private readonly string _connectionString = Common.ConfigurationProvider.ConnectionString;

        public async Task Insert(LengthData lengthData)
        {
            var insertCommand = "[dbo].[LengthData_Insert]";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = insertCommand;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@coilDataId", lengthData.CoilDataId);
                        command.Parameters.AddWithValue("@good", lengthData.Good);
                        command.Parameters.AddWithValue("@thicknessScrap", lengthData.ThicknessScrap);
                        command.Parameters.AddWithValue("@thicknessReclass", lengthData.ThicknessReclass);
                        command.Parameters.AddWithValue("@blisters", lengthData.Blisters);
                        command.Parameters.AddWithValue("@contamination", lengthData.Contamination);
                        command.Parameters.AddWithValue("@gas", lengthData.Gas);
                        command.Parameters.AddWithValue("@holes", lengthData.Holes);
                        command.Parameters.AddWithValue("@lumps", lengthData.Lumps);
                        command.Parameters.AddWithValue("@paperBreaks", lengthData.PaperBreaks);
                        command.Parameters.AddWithValue("@paperSplice", lengthData.PaperSplice);
                        command.Parameters.AddWithValue("@shiny", lengthData.Shiny);
                        command.Parameters.AddWithValue("@slitterDefect", lengthData.SlitterDefect);
                        command.Parameters.AddWithValue("@tapeInCoil", lengthData.TapeInCoil);
                        command.Parameters.AddWithValue("@wrinkles", lengthData.Wrinkles);
                        command.Parameters.AddWithValue("@width", lengthData.Width);
                        command.Parameters.AddWithValue("@other", lengthData.Other);
                        command.Parameters.AddWithValue("@salvage", lengthData.Salvage);
                        command.Parameters.AddWithValue("@linearMeters", lengthData.LinearMeters);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}