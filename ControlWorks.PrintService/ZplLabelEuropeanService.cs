﻿using ControlWorks.Utils.Logging;
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


        public ZplLabelEuropeanService(ZplLabelData data, ILogger logger)
        {
            Initialize(data, logger);
        }

        public override string GetLabel()
        {
            var zplLabel = new ZplLabel();

            var label = zplLabel.Load(
                ZplFactory.TextField().At(80, 50).SetFont("0", FieldOrientation.Normal, 124).WithData(LabelData.GeneratedMaterialType),
                ZplFactory.TextField().At(80, 160).SetFont("0", FieldOrientation.Normal, 124).WithData("RMR " + LabelData.GetRmR()),
                ZplFactory.BarcodeField().At(80, 270).BarWidth(4).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.GetRmR()).Height(120),
                ZplFactory.TextField().At(550, 270).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetTolerance()),
                ZplFactory.TextField().At(80, 416).SetFont("0", FieldOrientation.Normal, 60).WithData(LabelData.LinearMeters + " LM"),
                ZplFactory.BarcodeField().At(300, 416).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.B, FieldOrientation.Normal, 1).WithData(LabelData.RmR).Height(70).BarWidth(2),

                /****************             Inspection Field             ****************/
                ZplFactory.TextField().At(500, 500).SetFont("0", FieldOrientation.Normal, 60).WithData("INSP:"),
                ZplFactory.TextField().At(450, 560).SetFont("R", FieldOrientation.Normal, 40).WithData("LAB"),
                ZplFactory.TextField().At(600, 560).SetFont("R", FieldOrientation.Normal, 40).WithData("MATL INSP"),
                ZplFactory.TextField().At(440, 606).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetLabInspectionDateField()),
                ZplFactory.TextField().At(600, 606).SetFont("T", FieldOrientation.Normal, 12).WithData(LabelData.GetInspectionField()),
                ZplFactory.TextField().At(440, 660).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.LabInspector),
                ZplFactory.TextField().At(640, 660).SetFont("0", FieldOrientation.Normal, 72).WithData(LabelData.Inspector),
                /****************             Inspection Field             ****************/

                ZplFactory.TextField().At(80, 540).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetSqYards()),
                ZplFactory.TextField().At(80, 610).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetBatchField()),
                ZplFactory.TextField().At(80, 680).SetFont("R", FieldOrientation.Normal, 60).WithData(LabelData.GetChangeField()),

                /****************             Bottom Field             ****************/

                ZplFactory.TextField().At(80, 800).SetFont("0", FieldOrientation.Normal, 84).WithData(LabelData.GetCalibrationDateField()),
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
