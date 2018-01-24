Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO

Namespace StoreInDB
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private treeList1 As DevExpress.XtraTreeList.TreeList
		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private dataColumn2 As System.Data.DataColumn
		Private WithEvents simpleButtonSave As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButtonLoad As DevExpress.XtraEditors.SimpleButton
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.simpleButtonSave = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButtonLoad = New DevExpress.XtraEditors.SimpleButton()
			Me.dataSet1 = New System.Data.DataSet()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Top
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(472, 173)
			Me.treeList1.TabIndex = 0
			' 
			' simpleButtonSave
			' 
			Me.simpleButtonSave.Location = New System.Drawing.Point(13, 187)
			Me.simpleButtonSave.Name = "simpleButtonSave"
			Me.simpleButtonSave.Size = New System.Drawing.Size(114, 20)
			Me.simpleButtonSave.TabIndex = 1
			Me.simpleButtonSave.Text = "Save"
'			Me.simpleButtonSave.Click += New System.EventHandler(Me.simpleButtonSave_Click);
			' 
			' simpleButtonLoad
			' 
			Me.simpleButtonLoad.Location = New System.Drawing.Point(140, 187)
			Me.simpleButtonLoad.Name = "simpleButtonLoad"
			Me.simpleButtonLoad.Size = New System.Drawing.Size(113, 20)
			Me.simpleButtonLoad.TabIndex = 2
			Me.simpleButtonLoad.Text = "Load"
'			Me.simpleButtonLoad.Click += New System.EventHandler(Me.simpleButtonLoad_Click);
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Locale = New System.Globalization.CultureInfo("en-US")
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2})
			Me.dataTable1.TableName = "LayoutData"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "LayoutName"
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "Data"
			Me.dataColumn2.DataType = GetType(Byte())
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(472, 261)
			Me.Controls.Add(Me.simpleButtonLoad)
			Me.Controls.Add(Me.simpleButtonSave)
			Me.Controls.Add(Me.treeList1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(treeList1)
			dataTable1.Rows.Add(New Object() {"Layout1"})
		End Sub

		Private Function GetLayoutData(ByVal tree As DevExpress.XtraTreeList.TreeList) As Byte()
			Dim stream As New MemoryStream()
			tree.SaveLayoutToStream(stream)
			Return stream.GetBuffer()
		End Function
		Private Sub SetLayoutData(ByVal tree As DevExpress.XtraTreeList.TreeList, ByVal data() As Byte)
			If data Is Nothing OrElse data.Length = 0 Then
				Return
			End If
			Dim stream As New MemoryStream(data)
			Try
				tree.RestoreLayoutFromStream(stream)
			Catch ex As Exception
				Throw New Exception("Wrong data format", ex)
			End Try
		End Sub

		Private Sub simpleButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButtonSave.Click
			dataTable1.Rows(0)("Data") = GetLayoutData(treeList1)
		End Sub

		Private Sub simpleButtonLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButtonLoad.Click
			Dim data() As Byte = TryCast(dataTable1.Rows(0)("Data"), Byte())
			SetLayoutData(treeList1, data)
		End Sub
	End Class
End Namespace
