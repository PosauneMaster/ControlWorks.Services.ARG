using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlWorks.Services
{
    public class CoilTypeMapper
    {
        public List<CoilType> MapFromCsv(string csvData)
        {
            try
            {
                var list = new List<CoilType>();
                var reader = new StringReader(csvData);
                var csv = new CsvReader(reader);
                csv.Configuration.HasHeaderRecord = true;

                while (csv.Read())
                {
                    var c = new CoilType
                    {
                        ToleranceMinus = csv.GetField<decimal?>("ToleranceMinus"),
                        TolerancePlus = csv.GetField<decimal?>("TolerancePlus"),
                        CalibrationDate = csv.GetField<DateTime?>("CalibrationDate"),
                        OriginalSqYards = csv.GetField<int?>("OriginalSqYards"),
                        CoilWidth = csv.GetField<short?>("CoilWidth"),
                        CoilNumber = csv.GetField<short?>("CoilNumber"),
                        CreatedDate = csv.GetField<DateTime?>("CreatedDate"),
                        ChangeNumber = csv.GetField<string>("ChangeNumber"),
                        RollNumber = csv.GetField<short?>("RollNumber"),
                        Inspector = csv.GetField<string>("Inspector"),
                        BatchNumber = csv.GetField<string>("BatchNumber"),
                        MaterialType = csv.GetField<string>("MaterialType"),
                        OvenPos = csv.GetField<int?>("OvenPos"),
                        MaterialThk = csv.GetField<decimal?>("MaterialThk"),
                        Length = csv.GetField<decimal?>("Length"),
                        Data = csv.GetField<string>("Data")
                    };

                    c.Nom = Math.Round((Math.Abs(c.ToleranceMinus.Value) + Math.Abs(c.TolerancePlus.Value)) / 2, 4);

                    list.Add(c);
                }

                return list;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        [NotMapped]
        public class CoilTypeDetailExtension : CoilType
        {
            public CoilType MapToBase()
            {
                var coilType = new CoilType
                {
                    CoilTypeId = 0,
                    ToleranceMinus = ToleranceMinus,
                    TolerancePlus = TolerancePlus,
                    CalibrationDate = CalibrationDate,
                    OriginalSqYards = OriginalSqYards,
                    CoilWidth = CoilWidth,
                    CoilNumber = CoilNumber,
                    CreatedDate = CreatedDate,
                    ChangeNumber = ChangeNumber,
                    RollNumber = RollNumber,
                    Inspector = Inspector,
                    BatchNumber = BatchNumber,
                    MaterialType = MaterialType,
                    OvenPos = OvenPos,
                    MaterialThk = MaterialThk,
                    Length = Length,
                    Data = Data
                };
                return coilType;
            }
        }

        public class CoilTypeDetailMap : CsvClassMap<CoilTypeDetailExtension>
        {
            public CoilTypeDetailMap()
            {
                Map(c => c.ToleranceMinus).Name("ToleranceMinus");
                Map(c => c.TolerancePlus).Name("TolerancePlus");
                Map(c => c.CalibrationDate).Name("CalibrationDate");
                Map(c => c.OriginalSqYards).Name("OriginalSqYards");
                Map(c => c.CoilWidth).Name("CoilWidth");
                Map(c => c.CoilNumber).Name("CoilNumber");
                Map(c => c.CreatedDate).Name("CreatedDate");
                Map(c => c.ChangeNumber).Name("ChangeNumber");
                Map(c => c.RollNumber).Name("RollNumber");
                Map(c => c.Inspector).Name("Inspector");
                Map(c => c.BatchNumber).Name("BatchNumber");
                Map(c => c.MaterialType).Name("MaterialType");
                Map(c => c.OvenPos).Name("OvenPos");
                Map(c => c.MaterialThk).Name("MaterialThk");
                Map(c => c.Length).Name("Length");
                Map(c => c.Data).Name("Data");


            }
        }
    }
}
