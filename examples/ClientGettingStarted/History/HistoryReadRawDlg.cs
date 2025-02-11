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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// Shows a dialog which demonstrates a basic read history operation.
    /// </summary>
    public partial class HistoryReadRawDlg : Form
    {
        /// <summary>
        /// Synchronously reads historical values from the server.
        /// </summary>
        private void HistoryRead()
        {
            /// [History Read Raw]
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // parse the object id.
                NodeId nodeId = NodeId.Parse(NodeIdTB.Text);

                ReadRawModifiedDetails details = m_details as ReadRawModifiedDetails;
                HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();

                if (m_nodeToContinue == null)
                {
                    m_dataset.Tables[0].Rows.Clear();

                    details = new ReadRawModifiedDetails();
                    details.StartTime = (StartTimeCK.Checked) ? StartTimeDP.Value.ToUniversalTime() : DateTime.MinValue;
                    details.EndTime = (EndTimeCK.Checked) ? EndTimeDP.Value.ToUniversalTime() : DateTime.MinValue;
                    details.NumValuesPerNode = (MaxReturnValuesCK.Checked) ? (uint)MaxReturnValuesNP.Value : 0;
                    details.IsReadModified = false;
                    details.ReturnBounds = ReturnBoundsCK.Checked;

                    nodesToRead.Add(new HistoryReadValueId() { NodeId = nodeId });

                    m_details = details;
                    m_nodeToContinue = nodesToRead[0];
                }
                else
                {
                    nodesToRead.Add(m_nodeToContinue);
                }

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // fetch the history (with a 10s timeout).
                List<HistoryDataReadResult> results = session.HistoryReadRaw(
                    nodesToRead,
                    details,
                    TimestampsToReturn.Source,
                    new RequestSettings() { OperationTimeout = 10000 });

                // check for operation error.
                if (StatusCode.IsBad(results[0].StatusCode))
                {
                    m_parent.ShowError(this, "Read history call failed: " + results[0].StatusCode.ToString());
                    m_details = null;
                    m_nodeToContinue = null;
                    return;
                }

                // update controls.
                if (results[0].DataValues != null)
                {
                    foreach (DataValue value in results[0].DataValues)
                    {
                        AddValue(value, null);
                    }

                    m_dataset.AcceptChanges();
                }

                // save continuation point.
                if (!ByteString.IsNull(results[0].ContinuationPoint))
                {
                    m_nodeToContinue.ContinuationPoint = results[0].ContinuationPoint;
                    ReleaseContinuationPointBTN.Visible = true;
                }
                else
                {
                    m_nodeToContinue = null;
                    ReleaseContinuationPointBTN.Visible = false;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                m_nodeToContinue = null;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            /// [History Read Raw]
        }

        /// <summary>
        /// Asynchronously reads historical values from the server.
        /// </summary>
        private void BeginHistoryRead()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // parse the object id.
                NodeId nodeId = NodeId.Parse(NodeIdTB.Text);

                ReadRawModifiedDetails details = m_details as ReadRawModifiedDetails;
                HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();

                if (m_nodeToContinue == null)
                {
                    m_dataset.Tables[0].Rows.Clear();

                    details = new ReadRawModifiedDetails();
                    details.StartTime = (StartTimeCK.Checked) ? StartTimeDP.Value.ToUniversalTime() : DateTime.MinValue;
                    details.EndTime = (EndTimeCK.Checked) ? EndTimeDP.Value.ToUniversalTime() : DateTime.MinValue;
                    details.NumValuesPerNode = (MaxReturnValuesCK.Checked) ? (uint)MaxReturnValuesNP.Value : 0;
                    details.IsReadModified = false;
                    details.ReturnBounds = ReturnBoundsCK.Checked;

                    nodesToRead.Add(new HistoryReadValueId() { NodeId = nodeId });

                    m_details = details;
                    m_nodeToContinue = nodesToRead[0];
                }
                else
                {
                    nodesToRead.Add(m_nodeToContinue);
                }

                // fetch the history (with a 10s timeout).
                session.BeginHistoryReadRaw(
                    nodesToRead,
                    details,
                    TimestampsToReturn.Source,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnHistoryReadComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                m_nodeToContinue = null;
            }
        }

        /// <summary>
        /// Finishes an asynchronous history read request.
        /// </summary>
        private void OnHistoryReadComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnHistoryReadComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<HistoryDataReadResult> results = session.EndHistoryReadRaw(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // check for operation error.
                if (StatusCode.IsBad(results[0].StatusCode))
                {
                    m_parent.ShowError(this, "Read history call failed: " + results[0].StatusCode.ToString());
                    m_details = null;
                    m_nodeToContinue = null;
                    return;
                }

                // update controls.
                if (results[0].DataValues != null)
                {
                    foreach (DataValue value in results[0].DataValues)
                    {
                        AddValue(value, null);
                    }

                    m_dataset.AcceptChanges();
                }

                // save continuation point.
                if (!ByteString.IsNull(results[0].ContinuationPoint))
                {
                    m_nodeToContinue.ContinuationPoint = results[0].ContinuationPoint;
                    ReleaseContinuationPointBTN.Visible = true;
                }
                else
                {
                    m_nodeToContinue = null;
                    ReleaseContinuationPointBTN.Visible = false;
                }
            }
            catch (Exception exception)
            {
                // don't display any error if the session has changed.
                if (Object.ReferenceEquals(session, m_parent.Session) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                    m_nodeToContinue = null;
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadHistoryDlg"/> class.
        /// </summary>
        public HistoryReadRawDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;

            ResultsDV.AutoGenerateColumns = false;

            m_dataset = new DataSet();
            m_dataset.Tables.Add("Results");

            m_dataset.Tables[0].Columns.Add("Index", typeof(int));
            m_dataset.Tables[0].Columns.Add("SourceTimestamp", typeof(string));
            m_dataset.Tables[0].Columns.Add("ServerTimestamp", typeof(string));
            m_dataset.Tables[0].Columns.Add("Value", typeof(Variant));
            m_dataset.Tables[0].Columns.Add("StatusCode", typeof(StatusCode));
            m_dataset.Tables[0].Columns.Add("HistoryInfo", typeof(string));
            m_dataset.Tables[0].Columns.Add("UpdateType", typeof(HistoryUpdateType));
            m_dataset.Tables[0].Columns.Add("UpdateTime", typeof(string));
            m_dataset.Tables[0].Columns.Add("UserName", typeof(string));
            m_dataset.Tables[0].Columns.Add("DataValue", typeof(DataValue));

            m_dataset.Tables[0].DefaultView.Sort = "Index";

            ResultsDV.DataSource = m_dataset.Tables[0];

            NodeIdTB.Text = "ns=2;s=Demo.History.Historian_2";
            StartTimeDP.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            EndTimeDP.Value = DateTime.Now;
            MaxReturnValuesNP.Value = 10;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private DataSet m_dataset;
        private int m_nextId;
        private HistoryReadDetails m_details;
        private HistoryReadValueId m_nodeToContinue;
        #endregion

        #region Private Methods
        /// <summary>
        /// Adds a value to the grid.
        /// </summary>
        private void AddValue(DataValue value, ModificationInfo modificationInfo)
        {
            DataRow row = m_dataset.Tables[0].NewRow();

            m_nextId += 10000;

            row[0] = m_nextId;
            UpdateRow(row, value, modificationInfo);

            m_dataset.Tables[0].Rows.Add(row);
        }

        /// <summary>
        /// Updates a value in the grid.
        /// </summary>
        private void UpdateRow(DataRow row, DataValue value, ModificationInfo modificationInfo)
        {
            row[1] = value.SourceTimestamp.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff");
            row[2] = value.ServerTimestamp.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff");
            row[3] = value.WrappedValue;
            row[4] = new StatusCode(value.StatusCode.Code);
            row[5] = value.StatusCode.AggregateBits.ToString();

            if (modificationInfo != null)
            {
                row[6] = modificationInfo.UpdateType;
                row[7] = modificationInfo.ModificationTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                row[8] = modificationInfo.UserName;
            }

            row[9] = value;
        }

        /// <summary>
        /// Saves a continuation point for later use.
        /// </summary>
        private void SaveContinuationPoint(HistoryReadDetails details, HistoryReadValueId nodeToRead, byte[] continuationPoint)
        {
            // clear existing continuation point.
            if (m_nodeToContinue != null)
            {
                HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();
                nodesToRead.Add(m_nodeToContinue);
                m_parent.Session.ReleaseHistoryContinuationPoints(nodesToRead);
            }

            m_details = null;
            m_nodeToContinue = null;

            // save new continuation point.
            if (continuationPoint != null && continuationPoint.Length > 0)
            {
                m_details = details;
                m_nodeToContinue = nodeToRead;
                m_nodeToContinue.ContinuationPoint = continuationPoint;
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void Show(MainForm parent)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            InstructionsLB.Text = parent.GetInstructions(this.GetType());
            NodeIdTB_TextChanged(this, null);
            m_nodeToContinue = null;
            Show();
        }
        #endregion

        #region Event Handlers
        private void ReadHistoryBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    HistoryRead();
                }
                else
                {
                    BeginHistoryRead();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReleaseContinuationPointBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_parent == null)
                {
                    return;
                }

                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // release the continuation point.
                if (m_nodeToContinue != null)
                {
                    HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();
                    nodesToRead.Add(m_nodeToContinue);
                    session.ReleaseHistoryContinuationPoints(nodesToRead);
                    m_nodeToContinue = null;
                    ReleaseContinuationPointBTN.Visible = false;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void NodeIdBTN_Click(object sender, EventArgs e)
        {
            if (m_parent != null)
            {
                m_parent.OnNodeIdButtonClick(this, NodeIdTB);
                ReleaseContinuationPointBTN_Click(sender, e);
            }
        }

        private void NodeIdTB_TextChanged(object sender, EventArgs e)
        {
            if (m_parent != null)
            {
                m_parent.OnNodeIdTextChanged(NodeIdTB);
                ReleaseContinuationPointBTN_Click(sender, e);
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartTimeCK_CheckedChanged(object sender, EventArgs e)
        {
            StartTimeDP.Enabled = StartTimeCK.Checked;
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void EndTimeCK_CheckedChanged(object sender, EventArgs e)
        {
            EndTimeDP.Enabled = EndTimeCK.Checked;
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void MaxReturnValuesCK_CheckedChanged(object sender, EventArgs e)
        {
            MaxReturnValuesNP.Enabled = MaxReturnValuesCK.Checked;
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void StartTimeDP_ValueChanged(object sender, EventArgs e)
        {
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void EndTimeDP_ValueChanged(object sender, EventArgs e)
        {
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void MaxReturnValuesNP_ValueChanged(object sender, EventArgs e)
        {
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void ReturnBoundsCK_CheckedChanged(object sender, EventArgs e)
        {
            ReleaseContinuationPointBTN_Click(sender, e);
        }

        private void ShowCodeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                m_parent.ShowCode(this.GetType());
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ShowHelpBTN_Click(object sender, EventArgs e)
        {
            try
            {
                m_parent.ShowHelp(this.GetType());
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        #endregion
    }
}
