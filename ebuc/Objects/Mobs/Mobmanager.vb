Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class Mobmanager
    Dim def(9) As Mob.Defauld
    Dim akcx, akcz As Integer
    Dim text As Font
    Dim gw As Integer
    Sub load(device As Device)
        Dim rnd As New Random(Now.Millisecond)
        akcx = 0
        akcz = 0
        For i = 0 To 9
            Dim f As New Mob.Defauld
            f.px = rnd.Next(1, 16) * 4
            f.pz = rnd.Next(1, 16) * 4
            f.speed = 2
            f.load(device)
            f.sicht = 5 * 4
            def(i) = f
        Next
        text = New Font(device, Form1.Font)
    End Sub
    Sub draw(device As Device, ppx As Integer, ppz As Integer, gakcx As Integer, gakcz As Integer)
        For Each f As Mob.Defauld In def
            f.akcx = gakcx
            f.akcz = gakcz
            f.draw(device, ppx, ppz)
        Next

    End Sub
    Sub key(e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            gw += 1
            If gw = 10 Then
                gw = 0
            End If
        End If
    End Sub
End Class