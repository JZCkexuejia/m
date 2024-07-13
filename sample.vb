Dim number As Integer
Dim contentnum As Double
Dim pattern As String = "^\d+(\.\d+)?$" ' 匹配整数或小数（整数部分至少一位，小数部分可选） 

If Regex.IsMatch(txtContent2.Text, pattern) = False Then
            ' 输入是有效的数字或小数  
            MessageBox.Show("内容请输入数字或者小数")
            Return
End If

Dim row As String = txtRowName.Text
Dim column As String = txtColName.Text
Dim content As Double = txtContent2.Text
Dim Msg As String = ""

Dim rowIndex As Integer = -1 '后续如果还是等于-1就相当于没有找到单元格'
Dim colIndex As Integer = -1

For Each datarow As DataGridViewRow In DataGridView1.Rows
            ' 检查"Name"列的值是否匹配  
    If datarow.Cells("Component").Value.ToString() = row Then
                rowIndex = datarow.Index
                Exit For
    End If
Next


colIndex = DataGridView1.Columns.IndexOf(DataGridView1.Columns(column))

If rowIndex = -1 Then
            MessageBox.Show("行不存在")
            Return
End If

If colIndex = -1 Then
            MessageBox.Show("列不存在")
            Return
End If
DataGridView1.Rows(rowIndex).Cells(colIndex).Style.BackColor = Color.Yellow



Dim result As DialogResult = MessageBox.Show("你确定要执行这个操作吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' 根据用户的响应执行操作  
If result = DialogResult.No Then
            Return
End If