Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Public Class Batchs
    Dim connectionString As String = Conexion.ObtenerConexion.ConnectionString
    Private Sub Batchs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub load(itemcode As String)
        Label1.Text = itemcode
        CargaItems(itemcode)
    End Sub

    Public Function CargaItems(itemcode As String)
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("WITH batchs AS
(
SELECT T0.ItemCode,T1.WhsCode,T0.BatchNum,SUM(CASE T0.Direction when 0 then 1 else -1 end * T0.Quantity) as Quantitys 
FROM IBT1 T0 INNER JOIN OWHS T1 ON T0.WhsCode = T1.WhsCode
GROUP BY T0.BatchNum, T1.WhsCode,  T0.ItemCode)
SELECT ItemCode,WhsCode,BatchNum, Quantitys  from batchs where Quantitys > 0 and ItemCode ='" + itemcode + "' 
", con)
        Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
        If existe = False Then
            DGV.Columns.Add(i)
            i.HeaderText = "CHK"
            i.Name = "CHK"
            i.Width = 32
            i.DisplayIndex = 0
        End If
        Dim DT_dat As System.Data.DataTable = New System.Data.DataTable()
        SQL_da.Fill(DT_dat)
        DGV.DataSource = DT_dat
        con.Close()
    End Function
End Class