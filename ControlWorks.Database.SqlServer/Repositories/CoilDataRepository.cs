using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public class CoilDataRepository : Repository<CoilData>
    {
        public CoilDataRepository() { }
        public CoilDataRepository(CoilInfoContext context) : base(context)
        {
        }

        public int Insert(CoilDataInternal coilData)
        {
            var entity = MapFromInternal(coilData);
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity.CoilDataId;
        }

        private CoilData MapFromInternal(CoilDataInternal data)
        {
            var entity = new CoilData
            {
               
                MaterialType = data.MaterialType,
                MaterialThickness = data.MaterialThickness,
                OriginalSqYards = data.OriginalSqYards,
                BatchNumber = data.BatchNumber,
                ChangeNumber = data.ChangeNumber,
                ExtrusionDate = data.ExtrusionDate,
                RollSnNumber = data.RollSnNumber,
                CoilNumber = data.CoilNumber,
                CoilWidth = data.CoilWidth,
                TolerancePlus = data.TolerancePlus,
                ToleranceMinus = data.ToleranceMinus,
                Inspector = data.Inspector,
                InspectionDateTime = data.InspectionDateTime,
                CalibrationDate = data.CalibrationDate,
                GeneratedMaterialType = data.GeneratedMaterialType,
                BatchRunTimestamp = data.BatchRunTimestamp,
                MachineNumber = data.MachineNumber,
                CoilSnNumber = data.Coil_SN_Number,
                LabInspector = data.LabInspector,
                LabInspectDate = data.LabInspectDate,
                RollNumber = data.RollNumber
            };

            return entity;
        }
    }
}
