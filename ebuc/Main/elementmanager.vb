Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class elementmanager
    Dim c As New cube
    Dim boden As New boden
    Dim mobs As New Mobmanager
    Sub load(device As Device)
        c.load(device)
        boden.load(device)
        mobs.load(device)
    End Sub
    Sub draw(device As Device)
        boden.draw(device)


        mobs.draw(device, c.px, c.pz, c.akcx, c.akcz)
        c.draw(device)

    End Sub
    Sub key(e As KeyEventArgs)
        c.key(e)
        boden.key(e)
        mobs.key(e)
    End Sub
End Class
