/******************************************************************************
** Copyright (c) 2006-2023 Unified Automation GmbH All rights reserved.
**
** Software License Agreement ("SLA") Version 2.8
**
** Unless explicitly acquired and licensed from Licensor under another
** license, the contents of this file are subject to the Software License
** Agreement ("SLA") Version 2.8, or subsequent versions
** as allowed by the SLA, and You may not copy or use this file in either
** source code or executable form, except in compliance with the terms and
** conditions of the SLA.
**
** All software distributed under the SLA is provided strictly on an
** "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
** AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
** LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
** PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the SLA for specific
** language governing rights and limitations under the SLA.
**
** Project: .NET based OPC UA Client Server SDK
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
******************************************************************************/

#region Copyright
//------------------------------------------------------------------------
//   OPC UA - Example Client
//
//   Copyright (C) Unified Automation GmbH 2012  All Rights Reserved. Confidential
//------------------------------------------------------------------------
#endregion Copyright

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Unified.OpcUA;
//using Opc.Ua;
//using Opc.Ua.Client;

namespace Unified.OpcUA.Client
{
    public partial class MonitoredItemsControl : UserControl
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader VariableNameCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeadbandMI;

        public MonitoredItemsControl()
        {
            InitializeComponent();
        }




        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeListControl));


            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.MonitoredItemIdCH = new System.Windows.Forms.ColumnHeader();
            this.VariableNameCH = new System.Windows.Forms.ColumnHeader();
            this.ValueCH = new System.Windows.Forms.ColumnHeader();
            this.QualityCH = new System.Windows.Forms.ColumnHeader();
            this.TimestampCH = new System.Windows.Forms.ColumnHeader();

            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Monitoring_DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new System.Windows.Forms.ToolStripMenuItem();

            //
            // MonitoredItemsLV
            //
            this.MonitoredItemsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
           this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonitoredItemIdCH,
            this.VariableNameCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH});
            this.MonitoredItemsLV.ContextMenuStrip = this.MonitoringMenu;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 233);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(1047, 123);
            this.MonitoredItemsLV.TabIndex = 8;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            //
            // MonitoredItemIdCH
            //
            this.MonitoredItemIdCH.Text = "ID";
            //
            // VariableNameCH
            //
            this.VariableNameCH.Text = "Variable";
            //
            // ValueCH
            //
            this.ValueCH.Text = "Value";
            //
            // QualityCH
            //
            this.QualityCH.Text = "Quality";
            //
            // TimestampCH
            //
            this.TimestampCH.Text = "Timestamp";
            this.TimestampCH.Width = 109;
            //
            // MonitoringMenu
            //
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(167, 92);

        }
    }

}
