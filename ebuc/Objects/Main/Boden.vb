Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class boden
    Dim v(5) As CustomVertex.PositionNormalTextured
    Dim tex As Texture
    Sub load(device As Device)
        v(0) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = -2, .Z = -2, .Tv = 0, .Tu = 0}
        v(2) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = -2, .Z = 2, .Tv = 0, .Tu = 1}
        v(1) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = -2, .Tv = 1, .Tu = 0}
        v(3) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = 2, .Tv = 1, .Tu = 1}
        v(5) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = -2, .Z = 2, .Tv = 0, .Tu = 1}
        v(4) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = -2, .Tv = 1, .Tu = 0}
        tex = TextureLoader.FromFile(device, "REcources/bboden1.png")
    End Sub
    Sub draw(device As Device)
        device.VertexFormat = CustomVertex.PositionNormalTextured.Format
        device.SetTexture(0, tex)

        For i As Integer = -15 To 32
            For ii As Integer = -15 To 32
                device.Transform.World = Matrix.Identity
                device.Transform.World = Matrix.Translation(i * 4, 0, ii * 4)
                device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)
            Next
        Next

       


    End Sub
    Sub key(e As KeyEventArgs)

    End Sub
End Class
