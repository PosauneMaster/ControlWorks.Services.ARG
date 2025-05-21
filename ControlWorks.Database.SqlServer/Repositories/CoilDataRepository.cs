using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlWorks.Common;


namespace ControlWorks.Database.SqlServer.Repositories
{
    public class CoilDataRepository
    {
        private readonly string _connectionString;

        public CoilDataRepository()
        {
            _connectionString = Common.ConfigurationProvider.ConnectionString;

        }

        public int Insert(CoilDataInternal coilData, string ipAddress, string cpuName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = BuildInsertString();

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
                    command.Parameters.AddWithValue("@ipAddress", ipAddress);
                    command.Parameters.AddWithValue("@cpuName", cpuName);
                }

            }

            return 0;
        }

        private string BuildInsertString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[CoilData]");
            sb.AppendLine("([MaterialType]");
            sb.AppendLine(",[MaterialThickness]");
            sb.AppendLine(",[OriginalSqYards]");
            sb.AppendLine(",[BatchNumber]");
            sb.AppendLine(",[ChangeNumber]");
            sb.AppendLine(",[ExtrusionDate]");
            sb.AppendLine(",[RollSnNumber]");
            sb.AppendLine(",[CoilNumber]");
            sb.AppendLine(",[CoilWidth]");
            sb.AppendLine(",[TolerancePlus]");
            sb.AppendLine(",[ToleranceMinus]");
            sb.AppendLine(",[Inspector]");
            sb.AppendLine(",[InspectionDateTime]");
            sb.AppendLine(",[CalibrationDate]");
            sb.AppendLine(",[GeneratedMaterialType]");
            sb.AppendLine(",[OvenPos]");
            sb.AppendLine(",[BatchRunTimestamp]");
            sb.AppendLine(",[MachineNumber]");
            sb.AppendLine(",[CoilSnNumber]");
            sb.AppendLine(",[LabInspector]");
            sb.AppendLine(",[RollNumber]");
            sb.AppendLine(",[LabInspectDate]");
            sb.AppendLine(",[IpAddress]");
            sb.AppendLine(",[CpuName])");
            sb.AppendLine("VALUES");
            sb.AppendLine("(@materialType");
            sb.AppendLine(",@materialThickness");
            sb.AppendLine(",@originalSqYards");
            sb.AppendLine(",@batchNumber");
            sb.AppendLine(",@changeNumber");
            sb.AppendLine(",@extrusionDate");
            sb.AppendLine(",@rollSnNumber");
            sb.AppendLine(",@coilNumber");
            sb.AppendLine(",@coilWidth");
            sb.AppendLine(",@tolerancePlus");
            sb.AppendLine(",@toleranceMinus");
            sb.AppendLine(",@inspector");
            sb.AppendLine(",@inspectionDateTime");
            sb.AppendLine(",@calibrationDate");
            sb.AppendLine(",@generatedMaterialType");
            sb.AppendLine(",@ovenPos");
            sb.AppendLine(",@batchRunTimestamp");
            sb.AppendLine(",@machineNumber");
            sb.AppendLine(",@coilSnNumber");
            sb.AppendLine(",@labInspector");
            sb.AppendLine(",@rollNumber");
            sb.AppendLine(",@labInspectDate");
            sb.AppendLine(",@ipAddress");
            sb.AppendLine(",@cpuName");

            return sb.ToString();

        }
    }
}
//    var entity = MapFromInternal(coilData);
        //    DbSet.Add(entity);
        //    Context.SaveChanges();
        //    return entity.CoilDataId;
        //}

        //private CoilData MapFromInternal(CoilDataInternal data)
        //{
        //    var entity = new CoilData
        //    {
               
        //        MaterialType = data.MaterialType,
        //        MaterialThickness = data.MaterialThickness,
        //        OriginalSqYards = data.OriginalSqYards,
        //        BatchNumber = data.BatchNumber,
        //        ChangeNumber = data.ChangeNumber,
        //        ExtrusionDate = data.ExtrusionDate,
        //        RollSnNumber = data.RollSnNumber,
        //        CoilNumber = data.CoilNumber,
        //        CoilWidth = data.CoilWidth,
        //        TolerancePlus = data.TolerancePlus,
        //        ToleranceMinus = data.ToleranceMinus,
        //        Inspector = data.Inspector,
        //        InspectionDateTime = data.InspectionDateTime,
        //        CalibrationDate = data.CalibrationDate,
        //        GeneratedMaterialType = data.GeneratedMaterialType,
        //        BatchRunTimestamp = data.BatchRunTimestamp,
        //        MachineNumber = data.MachineNumber,
        //        CoilSnNumber = data.Coil_SN_Number,
        //        LabInspector = data.LabInspector,
        //        LabInspectDate = data.LabInspectDate,
        //        RollNumber = data.RollNumber
        //    };

        //    return entity;
        //}
    //}
//}
