using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZplLabels.ZPL;

namespace ControlWorks.PrintService
{
    public class ZplLabelEuropeanService : ZplLabelService
    {
        public LabelSettingsEuropean LabelSettings { get; set; }

        public ZplLabelEuropeanService(ZplLabelData data, ILogger logger)
        {
            Initialize(data, logger);
        }

        public override string GetLabel()
        {
            var zplLabel = new ZplLabel();

            var label = zplLabel.Load(
                ZplFactory.TextField().At(LabelSettings.GeneratedMaterialType.X, LabelSettings.GeneratedMaterialType.Y).SetFont("0", FieldOrientation.Normal, 124).WithData(LabelData.GeneratedMaterialType),
                ZplFactory.TextField().At(LabelSettings.RMRText.X, LabelSettings.RMRText.Y).SetFont("0", FieldOrientation.Normal, 124).WithData("RMR " + LabelData.GetRmR()),
                ZplFactory.BarcodeField().At(LabelSettings.RMRBarcode.X, LabelSettings.RMRBarcode.Y).BarWidth(4).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.GetRmR()).Height(120),
                ZplFactory.TextField().At(LabelSettings.Tolerance.X, LabelSettings.Tolerance.Y).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetTolerance()),
                ZplFactory.TextField().At(LabelSettings.LinearMeters.X, LabelSettings.LinearMeters.Y).SetFont("0", FieldOrientation.Normal, 60).WithData(LabelData.LinearMeters + " LM"),
                ZplFactory.BarcodeField().At(LabelSettings.RMRFullBarcode.X, LabelSettings.RMRFullBarcode.Y).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.RmR).Height(70).BarWidth(2),

                /****************             Inspection Field             ****************/
                ZplFactory.TextField().At(LabelSettings.INSP.X, LabelSettings.INSP.Y).SetFont("0", FieldOrientation.Normal, 60).WithData("INSP:"),
                ZplFactory.TextField().At(LabelSettings.LAB.X, LabelSettings.LAB.Y).SetFont("R", FieldOrientation.Normal, 40).WithData("LAB"),
                ZplFactory.TextField().At(LabelSettings.MATLINSP.X, LabelSettings.MATLINSP.Y).SetFont("R", FieldOrientation.Normal, 40).WithData("MATL INSP"),
                ZplFactory.TextField().At(LabelSettings.LabInspectionDate.X, LabelSettings.LabInspectionDate.Y).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetLabInspectionDateField()),
                ZplFactory.TextField().At(LabelSettings.InspectionDate.X, LabelSettings.InspectionDate.Y).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetInspectionField()),
                ZplFactory.TextField().At(LabelSettings.LabInspector.X, LabelSettings.LabInspector.Y).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.LabInspector),
                ZplFactory.TextField().At(LabelSettings.Inspector.X, LabelSettings.Inspector.Y).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.Inspector),
                /****************             Inspection Field             ****************/

                ZplFactory.TextField().At(LabelSettings.SqYards.X, LabelSettings.SqYards.Y).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetSqYards()),
                ZplFactory.TextField().At(LabelSettings.BatchField.X, LabelSettings.BatchField.Y).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetBatchField()),
                ZplFactory.TextField().At(LabelSettings.Change.X, LabelSettings.Change.Y).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetChangeField()),

                /****************             Bottom Field             ****************/
                ZplFactory.TextField().At(LabelSettings.CalibrationDate.X, LabelSettings.CalibrationDate.Y).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.GetCalibrationDateField()),

                ZplFactory.TextField().At(LabelSettings.Batch1.X, LabelSettings.Batch1.Y).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.Batch),
                ZplFactory.BarcodeField().At(LabelSettings.Batch1Barcode.X, LabelSettings.Batch1Barcode.Y).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.A, FieldOrientation.Normal, 1).WithData(LabelData.Batch).Height(70).BarWidth(4),
                ZplFactory.BarcodeField().At(LabelSettings.CoilSerialNumber1Barcode.X, LabelSettings.CoilSerialNumber1Barcode.Y).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.A, FieldOrientation.Normal, 1).WithData(LabelData.CoilSerialNumber).Height(40).BarWidth(2),
                ZplFactory.TextField().At(LabelSettings.CoilSerialNumber1Text.X, LabelSettings.CoilSerialNumber1Text.Y).SetFont("T", FieldOrientation.Normal, 40).WithData(LabelData.CoilSerialNumber),
                
                ZplFactory.TextField().At(LabelSettings.Batch2.X, LabelSettings.Batch2.Y).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.Batch),
                ZplFactory.BarcodeField().At(LabelSettings.Batch2Barcode.X, LabelSettings.Batch2Barcode.Y).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.Batch).Height(70).BarWidth(4),
                ZplFactory.BarcodeField().At(LabelSettings.CoilSerialNumber2Barcode.X, LabelSettings.CoilSerialNumber2Barcode.Y).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.CoilSerialNumber).Height(40).BarWidth(2),
                ZplFactory.TextField().At(LabelSettings.CoilSerialNumber2Text.X, LabelSettings.CoilSerialNumber2Text.Y).SetFont("T", FieldOrientation.Normal, 40).WithData(LabelData.CoilSerialNumber)
                ).At(1, 1).ToString();

            return label;

        }

    }
}
