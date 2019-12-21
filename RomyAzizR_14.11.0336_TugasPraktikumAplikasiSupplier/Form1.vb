Imports System.Data
Imports System.Data.SqlClient


'@Author : Romy Aziz Risaldi 14.11.0336'
Public Class Form1
    Public Koneksi As String
    Public Sql1, Sql2, Sql3, Sql4 As String
    Public conn As SqlClient.SqlConnection = Nothing
    Public cmd As SqlClient.SqlCommand = Nothing
    Public dtadapter As SqlClient.SqlDataAdapter = Nothing
    Public dtreader As SqlClient.SqlDataReader = Nothing
    Public dttable As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Barang2DataSet.Master_Barang' table. You can move, or remove it, as needed.
        Me.Master_BarangTableAdapter.Fill(Me.Barang2DataSet.Master_Barang)
        'PERINTAH KONEKSI DATABASE DISIMPAN 1 BARIS
        Koneksi = "Data Source= localhost\sqlexpress;Initial Catalog=Barang2;Integrated Security=True"
        conn = New SqlClient.SqlConnection(Koneksi)
        conn.Open()
    End Sub

    Sub simpan()
        Sql1 = "Insert into Master_Barang values('" &
        Me.txtkode.Text & "','" & Me.txtnama.Text &
        "','" & Me.txtalamat.Text & "','" &
        Me.txttelp.Text & "')"
        cmd = New SqlClient.SqlCommand(Sql1)
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
    End Sub
    Sub daftar()
        Sql2 = "select * from Master_Barang"
        dtadapter = New SqlDataAdapter(Sql2, conn) 'dibuat satu baris
        Dim CST As New DataTable
        CST.Clear()
        dtadapter.Fill(CST)
        DataGridView1.DataSource = CST
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        kosong()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        simpan()
        kosong()
        MsgBox("Data Sudah Disimpan", MsgBoxStyle.Information,
        "Perhatian")
        daftar()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        kosong()
    End Sub

    Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles btnfind.Click
        cari()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        delete()
        daftar()
        MsgBox("Data Telah Terhapus", MsgBoxStyle.Information,
        "Informastion")
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Sub kosong()
        Me.txtkode.Text = ""
        Me.txtnama.Text = ""
        Me.txtalamat.Text = ""
        Me.txttelp.Text = ""
        Me.txtkode.Focus()
    End Sub
    Sub cari()
        Dim cari As String
        cari = InputBox("Masukan Kode Supplier", "Pencarian")
        Sql3 = "select * from Master_Barang where Kode_Supplier = '" &
        cari & "'"
        dtadapter = New SqlDataAdapter(Sql3, conn) 'dibuat satu baris
        Dim CST As New DataTable
        CST.Clear()
        dtadapter.Fill(CST)
        DataGridView1.DataSource = CST
    End Sub

    Sub delete()
        Dim hapus As String
        hapus = InputBox("Masukan Kode Supplier", "Penghapusan")
        Sql4 = "delete from Master_Barang where Kode_Supplier = '" &
        hapus & "'"
        cmd = New SqlClient.SqlCommand(Sql4)
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
    End Sub
End Class
