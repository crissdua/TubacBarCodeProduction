Imports SAPbobsCOM
Imports SAPbouiCOM
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient

Public Class Form1
    Public itemcode As String
    Dim valBarCode As String
    Dim oCompany As SAPbobsCOM.Company = Login.con.oCompany
    Dim Connected As Boolean = Login.con.Connected
    Dim connectionString As String = Conexion.ObtenerConexion.ConnectionString
    Public Ready As Boolean
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim wo As ProductionOrders = oCompany.GetBusinessObject(BoObjectTypes.oProductionOrders)
    Public Shared SQL_Conexion As SqlConnection = New SqlConnection()

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub ButtonRBC_Click(sender As Object, e As EventArgs) Handles ButtonRBC.Click
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        'DGV.Columns.Clear()
        CargaGridRecibo()
    End Sub
    Public Function CreaOrden()
        Try
            Dim reader = File.OpenText(System.Windows.Forms.Application.StartupPath + "\OS.txt")

            Dim line As String = Nothing

            Dim lines As Integer = 0

            While (reader.Peek() <> -1)
                line = reader.ReadLine()
                MsgBox("BarCode: " + line.ToString)
                System.Windows.Forms.Application.DoEvents()
                Dim oReturn As Integer = -1
                Dim oError As Integer = 0
                Dim errMsg As String = ""
                Dim sql As String
                Dim oRecordSet As SAPbobsCOM.Recordset
                Dim ItemCode As String
                Try
                    If oCompany.Connected = True Then
                        sql = ("select ItemCode from OITM where CodeBars = '" + line + "'")
                        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
                        oRecordSet.DoQuery(sql)
                        If oRecordSet.RecordCount > 0 Then
                            ItemCode = oRecordSet.Fields.Item(0).Value

                            Dim wo As ProductionOrders = oCompany.GetBusinessObject(BoObjectTypes.oProductionOrders)
                            wo.ItemNo = ItemCode
                            wo.DueDate = DateTime.Now()
                            wo.ProductionOrderType = BoProductionOrderTypeEnum.bopotSpecial
                            wo.Lines.ItemNo = "P10004"
                            wo.Lines.BaseQuantity = "1"
                            wo.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual
                            wo.Lines.WipAccount = "100000"
                            wo.Lines.Add()
                            oReturn = wo.Add()
                            'MessageBox.Show(wo.GetNewObjectCode().ToString)
                            Dim objectCode As String = oCompany.GetNewObjectKey()
                            wo.GetByKey(objectCode)
                            wo.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposReleased
                            wo.Update()



                            Dim objectCode2 As String = oCompany.GetNewObjectKey()

                            Dim oInvGenExit As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)
                            oInvGenExit.DocDate = Now ' it could be date.Today.
                            oInvGenExit.DocType = BoDocumentTypes.dDocument_Items
                            oInvGenExit.Lines.BaseType = 202
                            oInvGenExit.Lines.BaseEntry = objectCode2
                            oInvGenExit.Lines.BaseLine = 0
                            'oInvGenExit.Lines.Quantity = 1
                            'oInvGenExit.Lines.WarehouseCode = 02
                            'oInvGenExit.Lines.AccountCode = "100000"
                            oInvGenExit.Lines.Add()
                            oReturn = oInvGenExit.Add

                            Dim oreceipt As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
                            oreceipt.Lines.BaseEntry = objectCode2
                            oreceipt.Lines.BaseType = 202
                            oreceipt.Lines.Quantity = 1
                            oreceipt.Lines.TransactionType = SAPbobsCOM.BoTransactionTypeEnum.botrntReject

                            oreceipt.Lines.Add()

                            oReturn = oreceipt.Add
                            If oReturn <> 0 Then
                                MessageBox.Show(oCompany.GetLastErrorDescription)
                            End If
                        End If
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
                        oRecordSet = Nothing
                        GC.Collect()
                    End If
                Catch ex As Exception
                    MsgBox("Error: " + ex.Message.ToString)
                End Try

            End While
        Catch ex As Exception
            MsgBox("Error: " + ex.Message.ToString)
        End Try
    End Function
    Public Function CargaGridRecibo()
        Dim query1 As String
        query1 = ""
        Dim query2 As String
        query2 = ""
        Try
            Dim reader = File.OpenText(System.Windows.Forms.Application.StartupPath + "\OS.txt")

            Dim line As String = Nothing

            Dim lines As Integer = 0
            Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
            If existe = False Then
                DGV.Columns.Add(i)
                i.HeaderText = "CHK"
                i.Name = "CHK"
                i.Width = 32
                i.DisplayIndex = 0
            End If
            While (reader.Peek() <> -1)
                line = reader.ReadLine()
                Dim rnum As Integer = DGV.Rows.Add()
                DGV.Rows.Item(rnum).Cells(0).Value = line.ToString
                System.Windows.Forms.Application.DoEvents()
            End While
        Catch ex As Exception
        End Try


    End Function

    Public Function CargaItems()
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("select ItemCode,ItemName from OITM", con)
        Dim DT_dat As System.Data.DataTable = New System.Data.DataTable()
        SQL_da.Fill(DT_dat)
        DGV2.DataSource = DT_dat
        con.Close()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim query1 As String
            query1 = ""
            Dim query2 As String
            query2 = ""
            Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
            If existe = False Then
                DGV.Columns.Add(i)
                i.HeaderText = "CHK"
                i.Name = "CHK"
                i.Width = 32
                i.DisplayIndex = 0
            End If
            Dim result As Integer = MessageBox.Show("Desea Ingresar la Orden?", "Atencion", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                MessageBox.Show("Cancelado")
            ElseIf result = DialogResult.No Then
                MessageBox.Show("No se realizara la orden")
            ElseIf result = DialogResult.Yes Then
                For Each row As DataGridViewRow In DGV.Rows
                    Dim chk As DataGridViewCheckBoxCell = row.Cells("CHK")
                    If chk.Value IsNot Nothing AndAlso chk.Value = True Then
                        valBarCode = DGV.Rows(chk.RowIndex).Cells.Item(0).Value.ToString
                        'orden(valBarCode)
                        Encabezadoorder(valBarCode)
                    End If
                Next

            End If

        Catch ex As Exception
            MsgBox("No selecciono ningun codigo de barras, o bien ocurrio un error inesperado!")
        End Try
    End Sub

    Public Function linesorder()



        Dim i As Integer = 0
        While i < (DGV3.Rows.Count - 1)
            wo.Lines.ItemNo = DGV3.Rows(i).Cells(0).Value.ToString
            wo.Lines.BaseQuantity = Convert.ToDouble(DGV3.Rows(i).Cells(1).Value)
            wo.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual
            wo.Lines.WipAccount = "_SYS00000000029"
            wo.Lines.Add()
            i = i + 1
        End While
    End Function

    Public Function Encabezadoorder(line As String)
        Dim oReturn As Integer = -1
        Dim oError As Integer = 0
        Dim errMsg As String = ""
        Dim sql As String
        Dim oRecordSet As SAPbobsCOM.Recordset

        Dim contlinea As Integer = 0
        Try

            If Connected = True Then
                sql = ("select ItemCode from OITM where CodeBars = '" + line + "'")
                oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
                oRecordSet.DoQuery(sql)
                If oRecordSet.RecordCount > 0 Then
                    labelProducto.Text = oRecordSet.Fields.Item(0).Value
                    ItemCode = oRecordSet.Fields.Item(0).Value
                    'header inicio
                    wo.ItemNo = ItemCode
                    wo.DueDate = DateTime.Now()
                    wo.ProductionOrderType = BoProductionOrderTypeEnum.bopotSpecial
                    'header fin
                End If
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
                oRecordSet = Nothing
                GC.Collect()
            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message.ToString)
        End Try
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Public Function orden(line As String)
    '    Dim oReturn As Integer = -1
    '    Dim oError As Integer = 0
    '    Dim errMsg As String = ""
    '    Dim sql As String
    '    Dim oRecordSet As SAPbobsCOM.Recordset
    '    Dim sql2 As String
    '    Dim oRecordSet2 As SAPbobsCOM.Recordset
    '    Dim ItemCode As String
    '    Dim contlinea As Integer = 0
    '    Try

    '        If Connected = True Then
    '            sql = ("select ItemCode from OITM where CodeBars = '" + line + "'")
    '            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
    '            oRecordSet.DoQuery(sql)
    '            If oRecordSet.RecordCount > 0 Then
    '                labelProducto.Text = oRecordSet.Fields.Item(0).Value
    '                ItemCode = oRecordSet.Fields.Item(0).Value
    '                'header inicio
    '                wo.ItemNo = ItemCode
    '                wo.DueDate = DateTime.Now()
    '                wo.ProductionOrderType = BoProductionOrderTypeEnum.bopotStandard
    '                'header fin
    '                sql2 = ("SELECT T0.Code FROM ITT1 T0  INNER JOIN OITT T1 ON T0.Father = T1.Code WHERE T1.Code = '" + ItemCode + "'")
    '                oRecordSet2 = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
    '                oRecordSet2.DoQuery(sql)
    '                If oRecordSet2.RecordCount > 0 Then
    '                    'DocumentLines
    '                    'linesorder(oRecordSet2.Fields.Item(0).Value)
    '                End If
    '                oReturn = wo.Add()
    '            End If
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '            oRecordSet = Nothing
    '            GC.Collect()
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet2)
    '            oRecordSet2 = Nothing
    '            GC.Collect()
    '        End If
    '        '    wo.ItemNo = ItemCode
    '        '        wo.DueDate = DateTime.Now()
    '        '        wo.ProductionOrderType = BoProductionOrderTypeEnum.bopotStandard
    '        '        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '        '        oRecordSet = Nothing
    '        '        GC.Collect()

    '        '        'Contador de lineas para la orden
    '        '        sql = ("SELECT T0.Code FROM ITT1 T0  INNER JOIN OITT T1 ON T0.Father = T1.Code WHERE T1.Code = '" + ItemCode + "'")
    '        '        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
    '        '        oRecordSet.DoQuery(sql)
    '        '        If oRecordSet.RecordCount > 0 Then
    '        '            labelItem.Text = oRecordSet.Fields.Item(0).Value
    '        '        End If
    '        '        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '        '        oRecordSet = Nothing
    '        '        GC.Collect()


    '        '        'ESPERA BOTON

    '        '        sql = ("SELECT T0.Code FROM ITT1 T0  INNER JOIN OITT T1 ON T0.Father = T1.Code WHERE T1.Code = '" + ItemCode + "'")
    '        '        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
    '        '        oRecordSet.DoQuery(sql)
    '        '        If oRecordSet.RecordCount > 0 Then
    '        '            labelItem.Text = oRecordSet.Fields.Item(0).Value
    '        '        End If
    '        '        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '        '        oRecordSet = Nothing
    '        '        GC.Collect()




    '        '        wo.Lines.ItemNo = labelItem.Text
    '        '        wo.Lines.BaseQuantity = txtCant.Text
    '        '        wo.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual
    '        '        wo.Lines.WipAccount = "100000"
    '        '        wo.Lines.Add()

    '        '        oReturn = wo.Add()

    '        '        'MessageBox.Show(wo.GetNewObjectCode().ToString)
    '        '        Dim objectCode As String = oCompany.GetNewObjectKey()
    '        '        wo.GetByKey(objectCode)
    '        '        wo.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposReleased
    '        '        wo.Update()



    '        '        'Dim objectCode2 As String = oCompany.GetNewObjectKey()

    '        '        'Dim oInvGenExit As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)
    '        '        'oInvGenExit.DocDate = Now ' it could be date.Today.
    '        '        'oInvGenExit.DocType = BoDocumentTypes.dDocument_Items
    '        '        'oInvGenExit.Lines.BaseType = 202
    '        '        'oInvGenExit.Lines.BaseEntry = objectCode2
    '        '        'oInvGenExit.Lines.BaseLine = 0
    '        '        ''oInvGenExit.Lines.Quantity = 1
    '        '        ''oInvGenExit.Lines.WarehouseCode = 02
    '        '        ''oInvGenExit.Lines.AccountCode = "100000"
    '        '        'oInvGenExit.Lines.Add()
    '        '        'oReturn = oInvGenExit.Add

    '        '        'Dim oreceipt As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
    '        '        'oreceipt.Lines.BaseEntry = objectCode2
    '        '        'oreceipt.Lines.BaseType = 202
    '        '        'oreceipt.Lines.Quantity = 1
    '        '        'oreceipt.Lines.TransactionType = SAPbobsCOM.BoTransactionTypeEnum.botrntReject

    '        '        'oreceipt.Lines.Add()

    '        '        'oReturn = oreceipt.Add
    '        '        If oReturn <> 0 Then
    '        '            MessageBox.Show(oCompany.GetLastErrorDescription)
    '        '        End If
    '        '    End If
    '        '    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '        '    oRecordSet = Nothing
    '        '    GC.Collect()
    '        'End If
    '    Catch ex As Exception
    '        MsgBox("Error: " + ex.Message.ToString)
    '    End Try
    'End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaGridRecibo()
    End Sub

    Private Sub EnviarOrd_Click(sender As Object, e As EventArgs) Handles EnviarOrd.Click
        Try
            Dim sql As String
            Dim oRecordSet As SAPbobsCOM.Recordset
            Dim sql2 As String
            Dim oRecordSet2 As SAPbobsCOM.Recordset
            Dim contlinea As Integer = 0
            Dim oReturn As Integer = -1
            oReturn = wo.Add()
            If oReturn <> 0 Then
                MessageBox.Show(oCompany.GetLastErrorDescription)
            End If
            'MessageBox.Show(wo.GetNewObjectCode().ToString)
            Dim objectCode As String = oCompany.GetNewObjectKey()
            wo.GetByKey(objectCode)
            wo.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposReleased
            wo.Update()
            'Dim objectCode2 As String = oCompany.GetNewObjectKey()

            '--------------------------------------------------------------------------------------------------------------
            'RECIBO DE PRODUCCION -----------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------

            Dim oreceipt As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)



            oreceipt.Lines.BaseEntry = objectCode
            oreceipt.Lines.BaseType = 202
            oreceipt.Lines.Quantity = 1
            oreceipt.Lines.AccountCode = "_SYS00000000039"
            oreceipt.Lines.TransactionType = SAPbobsCOM.BoTransactionTypeEnum.botrntReject
            oreceipt.Lines.Add()
            contlinea = contlinea - 1

            oReturn = oreceipt.Add
            If oReturn <> 0 Then
                MessageBox.Show(oCompany.GetLastErrorDescription)
            End If

            '--------------------------------------------------------------------------------------------------------------
            'EMISION DE PRODUCCION -----------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------
            'Contador de lineas para la orden
            sql = ("SELECT count(T0.DocNum) FROM OWOR T0  INNER JOIN WOR1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.DocNum = '" + objectCode + "'")
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            If oRecordSet.RecordCount > 0 Then
                contlinea = oRecordSet.Fields.Item(0).Value
            End If
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()

            Dim oInvGenExit As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

            While contlinea <> 0
                oInvGenExit.DocDate = Now ' it could be date.Today.
                oInvGenExit.DocType = BoDocumentTypes.dDocument_Items
                oInvGenExit.Lines.BaseType = 202
                oInvGenExit.Lines.BaseEntry = objectCode
                oInvGenExit.Lines.BaseLine = 0
                oInvGenExit.Lines.BatchNumbers.BatchNumber = ""
                oInvGenExit.Lines.BatchNumbers.Quantity = 1
                oInvGenExit.Lines.BatchNumbers.Add()
                'oInvGenExit.Lines.Quantity = 1
                'oInvGenExit.Lines.WarehouseCode = 02
                oInvGenExit.Lines.AccountCode = "_SYS00000000039"
                oInvGenExit.Lines.Add()
                contlinea = contlinea - 1
            End While
            oReturn = oInvGenExit.Add

            oReturn = oInvGenExit.Add
            If oReturn <> 0 Then
                MessageBox.Show(oCompany.GetLastErrorDescription)
            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnAgregarLinea_Click(sender As Object, e As EventArgs) Handles BtnAgregarLinea.Click
        linesorder()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CargaItems()
    End Sub

    Private Sub DGV2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV2.CellContentClick
        txtArticulo.Clear()
        txtArticulo.Text = DGV2(0, DGV2.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim OrdersForm As New Batchs
        'OrdersForm.load(txtArticulo.Text)
        'OrdersForm.Show()

        DGV3.Rows.Add(txtArticulo.Text, txtCant.Text)
        txtArticulo.Clear()
        txtCant.Clear()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("select ItemCode,ItemName from OITM where itemcode LIKE '" + TextBox1.Text + "%'", con)
        Dim DT_dat As System.Data.DataTable = New System.Data.DataTable()
        SQL_da.Fill(DT_dat)
        DGV2.DataSource = DT_dat
        con.Close()
    End Sub
End Class
