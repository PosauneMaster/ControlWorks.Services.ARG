using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public class LengthDataRepository : Repository<LengthData>
    {
        public LengthDataRepository() { }

        public LengthDataRepository(CoilInfoContext context) : base(context)
        {
        }

        public int Insert(int coilDataId, LengthDataInternal lengthData)
        {
            var entity = MapFromInternal(coilDataId, lengthData);
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity.CoilDataId;
        }

        private LengthData MapFromInternal(int coilDataId, LengthDataInternal data)
        {
            var entity = new LengthData
            {
                Good = data.Good,
                Width = data.Width,
                CoilDataId = coilDataId,
                ThicknessScrap = data.ThicknessScrap,
                ThicknessReclass = data.ThicknessReclass,
                Blisters = data.Blisters,
                Contamination = data.Contamination,
                Gas = data.Gas,
                Holes = data.Holes,
                Lumps = data.Lumps,
                PaperBreaks = data.PaperBreaks,
                PaperSplice = data.PaperSplice,
                Shiny = data.Shiny,
                SlitterDefect = data.SlitterDefect,
                TapeInCoil = data.TapeInCoil,
                Wrinkles = data.Wrinkles,
                Other = data.Other,
                Salvage = data.Salvage,
                LinearMeters = data.LinearMeters
            };

            return entity;
        }
    }
}
