﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ExcelDna.Integration;
using ExcelDna.IntelliSense;

using ExcelDna.Integration.CustomUI;

using System.Runtime.InteropServices;



using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenericUDF
{
    [ComVisible(true)]
    public class Ribbon : ExcelRibbon
    {

        public override string GetCustomUI(string RibbonID)
        {
            return @"
<customUI xmlns='http://schemas.microsoft.com/office/2006/01/customui'>
    <ribbon>
    <tabs>
        <tab id='tab1' label='Claudio Tab'>
        <group id='group1' label='Fogli'>
            <button id='NumeraFogli' label='Numera Fogli' onAction='OnButtonPressedNumeraFogli'/>
        </group >
        <group id='group2' label='Celle'>
            <button id='CreaID' label='Crea ID' onAction='OnButtonPressedCreaID'/>
        </group >
        </tab>
    </tabs>
    </ribbon>
</customUI>";
        }


        public void OnButtonPressedNumeraFogli(IRibbonControl control)
        {
            try
            {
                var sheet = new ClassiDiScambio.NumeraFogli.Sheet((Excel.Application)ExcelDnaUtil.Application);

                var excelGui = new ExcelGui.NumeraFogli(sheet);
                excelGui.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void OnButtonPressedCreaID(IRibbonControl control)
        {
            try
            {
                var creaID = new ClassiDiScambio.Celle.CellID((Excel.Application)ExcelDnaUtil.Application);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


    }
}
