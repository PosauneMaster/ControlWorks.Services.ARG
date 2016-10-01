using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.UI.Console
{
    public class CoilInfoRepository
    {
        private CoilDataContext _context;

        public CoilInfoRepository()
        {
            _context = new CoilDataContext();
        }

        public List<CoilInfo> GetCoilInfo(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("cd.[CoilDataId]");
            sb.AppendLine(",cd.[MaterialType]");
            sb.AppendLine(",cd.[MaterialThickness]");
            sb.AppendLine(",cd.[OriginalSqYards]");
            sb.AppendLine(",cd.[BatchNumber]");
            sb.AppendLine(",cd.[ChangeNumber]");
            sb.AppendLine(",cd.[ExtrusionDate]");
            sb.AppendLine(",cd.[RollSnNumber]");
            sb.AppendLine(",cd.[CoilNumber]");
            sb.AppendLine(",cd.[CoilWidth]");
            sb.AppendLine(",cd.[TolerancePlus]");
            sb.AppendLine(",cd.[ToleranceMinus]");
            sb.AppendLine(",cd.[Inspector]");
            sb.AppendLine(",cd.[InspectionDateTime]");
            sb.AppendLine(",cd.[CalibrationDate]");
            sb.AppendLine(",cd.[GeneratedMaterialType]");
            sb.AppendLine(",cd.[OvenPos]");
            sb.AppendLine(",cd.[BatchRunTimestamp]");
            sb.AppendLine(",cd.[MachineNumber]");
            sb.AppendLine(",cd.[CoilSnNumber]");
            sb.AppendLine(",cd.[LabInspector]");
            sb.AppendLine(",cd.[RollNumber]");
            sb.AppendLine(",cd.[LabInspectDate]");
            sb.AppendLine(",ld.[LengthDataId]");
            sb.AppendLine(",ld.[CoilDataId]");
            sb.AppendLine(",ld.[Good]");
            sb.AppendLine(",ld.[ThicknessScrap]");
            sb.AppendLine(",ld.[ThicknessReclass]");
            sb.AppendLine(",ld.[Blisters]");
            sb.AppendLine(",ld.[Contamination]");
            sb.AppendLine(",ld.[Gas]");
            sb.AppendLine(",ld.[Holes]");
            sb.AppendLine(",ld.[Lumps]");
            sb.AppendLine(",ld.[PaperBreaks]");
            sb.AppendLine(",ld.[PaperSplice]");
            sb.AppendLine(",ld.[Shiny]");
            sb.AppendLine(",ld.[SlitterDefect]");
            sb.AppendLine(",ld.[TapeInCoil]");
            sb.AppendLine(",ld.[Wrinkles]");
            sb.AppendLine(",ld.[Width]");
            sb.AppendLine(",ld.[Other]");
            sb.AppendLine(",ld.[Salvage]");
            sb.AppendLine("FROM [CoilInfo].[dbo].[CoilData] cd");
            sb.AppendLine("JOIN [CoilInfo].[dbo].[LengthData] ld ON ld.CoilDataId = cd.CoilDataId");
            sb.AppendLine("WHERE[BatchRunTimestamp] >= @startDate AND[BatchRunTimestamp] <= @endDate");

            var list = _context.Database.SqlQuery<CoilInfo>(sb.ToString(), new SqlParameter("startDate", startDate), new SqlParameter("endDate", endDate));
            return list.ToList();
        }
    }
}
