using ControlWorks.Utils.Logging;
using ZplLabels.ZPL;

namespace ControlWorks.PrintService
{
    public class ZplLabelAmericanService : ZplLabelService
    {

        public ZplLabelAmericanService(ZplLabelData data, ILogger logger)
        {
            Initialize(data, logger);
        }

        protected override string GetLabel()
        {
            var zplLabel = new ZplLabel();

            var label = zplLabel.Load(
                ZplFactory.TextField().At(80, 50).SetFont("0", FieldOrientation.Normal, 124).WithData(LabelData.GeneratedMaterialType),
                ZplFactory.BarcodeField().At(10, 165).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.A, FieldOrientation.Normal, 1).WithData(LabelData.GeneratedMaterialType).Height(120).BarWidth(4).Centered(800),
                ZplFactory.TextField().At(80, 330).SetFont("0", FieldOrientation.Normal, 112).WithData(LabelData.SqYards),
                ZplFactory.BarcodeField().At(300, 330).SetBarcodeType(BarcodeType.Code128).SetFont("0", FieldOrientation.Normal, 1).WithData(LabelData.SqYards).Height(120).BarWidth(4),
                ZplFactory.TextField().At(500, 500).SetFont("0", FieldOrientation.Normal, 60).WithData("INSP:"),
                ZplFactory.TextField().At(450, 560).SetFont("R", FieldOrientation.Normal, 40).WithData("LAB"),
                ZplFactory.TextField().At(600, 560).SetFont("R", FieldOrientation.Normal, 40).WithData("MATL INSP"),
                ZplFactory.TextField().At(440, 606).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetLabInspectionDateField()),
                ZplFactory.TextField().At(600, 606).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetInspectionField()),
                ZplFactory.TextField().At(440, 660).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.LabInspector),
                ZplFactory.TextField().At(640, 660).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.Inspector),
                ZplFactory.TextField().At(80, 510).SetFont("T", FieldOrientation.Normal, 60).WithData(LabelData.GetToleranceField()),
                ZplFactory.TextField().At(80, 570).SetFont("T", FieldOrientation.Normal, 60).WithData(LabelData.GetChangeField()),
                ZplFactory.TextField().At(80, 630).SetFont("T", FieldOrientation.Normal, 60).WithData(LabelData.GetBatchField()),
                ZplFactory.TextField().At(80, 800).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.GetProductionDateField()),
                ZplFactory.TextField().At(80, 900).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.Batch),
                ZplFactory.BarcodeField().At(350, 900).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.A, FieldOrientation.Normal, 1).WithData(LabelData.Batch).Height(70).BarWidth(4),
                ZplFactory.BarcodeField().At(80, 980).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.A, FieldOrientation.Normal, 1).WithData(LabelData.CoilSerialNumber).Height(40).BarWidth(2),
                ZplFactory.TextField().At(500, 980).SetFont("T", FieldOrientation.Normal, 40).WithData(LabelData.CoilSerialNumber),
                ZplFactory.TextField().At(80, 1055).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.Batch),
                ZplFactory.BarcodeField().At(350, 1055).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.Batch).Height(70).BarWidth(4),
                ZplFactory.BarcodeField().At(80, 1145).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.CoilSerialNumber).Height(40).BarWidth(2),
                ZplFactory.TextField().At(500, 1145).SetFont("T", FieldOrientation.Normal, 40).WithData(LabelData.CoilSerialNumber)
                ).At(1, 1).ToString();

            return label;

        }

    }
}
