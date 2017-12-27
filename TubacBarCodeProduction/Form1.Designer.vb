<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BarCodes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonRBC = New System.Windows.Forms.Button()
        Me.txtTipMat = New System.Windows.Forms.TextBox()
        Me.txtEspesor = New System.Windows.Forms.TextBox()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtGrado = New System.Windows.Forms.TextBox()
        Me.txtGram = New System.Windows.Forms.TextBox()
        Me.txtRecubri = New System.Windows.Forms.TextBox()
        Me.txtGalv = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnAgregarLinea = New System.Windows.Forms.Button()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.labelProducto = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCant = New System.Windows.Forms.TextBox()
        Me.EnviarOrd = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BarCodes})
        Me.DGV.Location = New System.Drawing.Point(12, 60)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(199, 314)
        Me.DGV.TabIndex = 1
        '
        'BarCodes
        '
        Me.BarCodes.HeaderText = "BarCodes"
        Me.BarCodes.Name = "BarCodes"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(55, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Crear Ordenes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonRBC
        '
        Me.ButtonRBC.BackgroundImage = Global.TubacBarCodeProduction.My.Resources.Resources.Refresh
        Me.ButtonRBC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonRBC.Location = New System.Drawing.Point(181, 15)
        Me.ButtonRBC.Name = "ButtonRBC"
        Me.ButtonRBC.Size = New System.Drawing.Size(30, 25)
        Me.ButtonRBC.TabIndex = 0
        Me.ButtonRBC.UseVisualStyleBackColor = True
        '
        'txtTipMat
        '
        Me.txtTipMat.Location = New System.Drawing.Point(96, 65)
        Me.txtTipMat.Name = "txtTipMat"
        Me.txtTipMat.Size = New System.Drawing.Size(100, 20)
        Me.txtTipMat.TabIndex = 3
        '
        'txtEspesor
        '
        Me.txtEspesor.Location = New System.Drawing.Point(96, 91)
        Me.txtEspesor.Name = "txtEspesor"
        Me.txtEspesor.Size = New System.Drawing.Size(100, 20)
        Me.txtEspesor.TabIndex = 4
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(96, 117)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(100, 20)
        Me.txtAncho.TabIndex = 5
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(96, 143)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtPeso.TabIndex = 6
        '
        'txtGrado
        '
        Me.txtGrado.Location = New System.Drawing.Point(96, 169)
        Me.txtGrado.Name = "txtGrado"
        Me.txtGrado.Size = New System.Drawing.Size(100, 20)
        Me.txtGrado.TabIndex = 7
        '
        'txtGram
        '
        Me.txtGram.Location = New System.Drawing.Point(96, 195)
        Me.txtGram.Name = "txtGram"
        Me.txtGram.Size = New System.Drawing.Size(100, 20)
        Me.txtGram.TabIndex = 8
        '
        'txtRecubri
        '
        Me.txtRecubri.Location = New System.Drawing.Point(96, 221)
        Me.txtRecubri.Name = "txtRecubri"
        Me.txtRecubri.Size = New System.Drawing.Size(100, 20)
        Me.txtRecubri.TabIndex = 9
        '
        'txtGalv
        '
        Me.txtGalv.Location = New System.Drawing.Point(96, 247)
        Me.txtGalv.Name = "txtGalv"
        Me.txtGalv.Size = New System.Drawing.Size(100, 20)
        Me.txtGalv.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.txtArticulo)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.labelProducto)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtCant)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtEspesor)
        Me.Panel1.Controls.Add(Me.txtGalv)
        Me.Panel1.Controls.Add(Me.txtTipMat)
        Me.Panel1.Controls.Add(Me.txtRecubri)
        Me.Panel1.Controls.Add(Me.txtAncho)
        Me.Panel1.Controls.Add(Me.txtGram)
        Me.Panel1.Controls.Add(Me.txtPeso)
        Me.Panel1.Controls.Add(Me.txtGrado)
        Me.Panel1.Location = New System.Drawing.Point(217, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 362)
        Me.Panel1.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.TubacBarCodeProduction.My.Resources.Resources.Refresh
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(202, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 25)
        Me.Button2.TabIndex = 12
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnAgregarLinea
        '
        Me.BtnAgregarLinea.Location = New System.Drawing.Point(538, 322)
        Me.BtnAgregarLinea.Name = "BtnAgregarLinea"
        Me.BtnAgregarLinea.Size = New System.Drawing.Size(96, 23)
        Me.BtnAgregarLinea.TabIndex = 27
        Me.BtnAgregarLinea.Text = "Agregar Lineas"
        Me.BtnAgregarLinea.UseVisualStyleBackColor = True
        '
        'txtArticulo
        '
        Me.txtArticulo.Location = New System.Drawing.Point(96, 37)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(100, 20)
        Me.txtArticulo.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Nº Producto"
        '
        'labelProducto
        '
        Me.labelProducto.AutoSize = True
        Me.labelProducto.Location = New System.Drawing.Point(121, 8)
        Me.labelProducto.Name = "labelProducto"
        Me.labelProducto.Size = New System.Drawing.Size(42, 13)
        Me.labelProducto.TabIndex = 24
        Me.labelProducto.Text = "Articulo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Articulo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Cantidad"
        '
        'txtCant
        '
        Me.txtCant.Location = New System.Drawing.Point(96, 273)
        Me.txtCant.Name = "txtCant"
        Me.txtCant.Size = New System.Drawing.Size(100, 20)
        Me.txtCant.TabIndex = 19
        Me.txtCant.Text = "10"
        '
        'EnviarOrd
        '
        Me.EnviarOrd.Location = New System.Drawing.Point(549, 351)
        Me.EnviarOrd.Name = "EnviarOrd"
        Me.EnviarOrd.Size = New System.Drawing.Size(75, 23)
        Me.EnviarOrd.TabIndex = 12
        Me.EnviarOrd.Text = "Enviar"
        Me.EnviarOrd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 254)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Galvanizado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Recubrimiento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Gramaje"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Grado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Peso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Ancho"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Espesor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tipo Material"
        '
        'DGV2
        '
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(730, 60)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(199, 256)
        Me.DGV2.TabIndex = 12
        '
        'DGV3
        '
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Articulo, Me.Cantidad})
        Me.DGV3.Location = New System.Drawing.Point(460, 12)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(253, 304)
        Me.DGV3.TabIndex = 13
        '
        'Articulo
        '
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(73, 310)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "+ Linea"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(730, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(199, 20)
        Me.TextBox1.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(730, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Buscar Item"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 387)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.BtnAgregarLinea)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.ButtonRBC)
        Me.Controls.Add(Me.EnviarOrd)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tubac - BarCode"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As DataGridView
    Friend WithEvents BarCodes As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonRBC As Button
    Friend WithEvents txtTipMat As TextBox
    Friend WithEvents txtEspesor As TextBox
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents txtGrado As TextBox
    Friend WithEvents txtGram As TextBox
    Friend WithEvents txtRecubri As TextBox
    Friend WithEvents txtGalv As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EnviarOrd As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCant As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents labelProducto As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtArticulo As TextBox
    Friend WithEvents BtnAgregarLinea As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DGV2 As DataGridView
    Friend WithEvents DGV3 As DataGridView
    Friend WithEvents Articulo As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label12 As Label
End Class
