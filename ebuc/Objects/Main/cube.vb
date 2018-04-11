Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class cube
    Dim v(5) As CustomVertex.PositionNormalTextured
    Dim tex As Texture
    Public cpx, cpz As Decimal
    Dim m As Matrix
    Public dreh As Byte
    Public px As Integer = 4
    Public pz As Integer = 4
    Public akcx, akcz As Integer
    Dim d, d2 As Integer
    Dim f As Font
    Dim speed As Decimal
    Sub load(device As Device)
        v(0) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = -2, .Z = 0, .Tv = 0, .Tu = 0}
        v(1) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = 2, .Z = 0, .Tv = 0, .Tu = 1}
        v(2) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = 0, .Tv = 1, .Tu = 0}
        v(3) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = 2, .Z = 0, .Tv = 1, .Tu = 1}
        v(4) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = 2, .Z = 0, .Tv = 0, .Tu = 1}
        v(5) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = 0, .Tv = 1, .Tu = 0}
        tex = TextureLoader.FromFile(device, "REcources/cube.png")
        f = New Font(device, New Drawing.Font("Arial", 12))
        cpx = 4
        cpz = 4
        speed = 5
    End Sub
    Sub draw(device As Device)
        device.Transform.View = Matrix.LookAtLH(New Vector3(cpx - 20, 30, cpz - 5), New Vector3(cpx, 0, cpz), New Vector3(0, 1, 0))
        Select Case dreh
            Case Is = 1
                If px = 64 Then
                    px = 0
                    akcx += 1
                End If
                drehdig(True, True)
            Case Is = 2
                If px = 4 Then
                    px = 68
                    akcx -= 1
                End If
                drehdig(True, False)

            Case Is = 3
                If pz = 64 Then
                    pz = 0
                    akcz += 1
                End If
                drehdig(False, True)
            Case Is = 4
                If pz = 4 Then
                    pz = 68
                    akcz -= 1
                End If
                drehdig(False, False)
            Case Else
                m = Matrix.Identity
                m *= Matrix.Translation(px, 0, pz)
        End Select


        device.VertexFormat = CustomVertex.PositionNormalTextured.Format
        device.Transform.World = Matrix.Identity
        device.SetTexture(0, tex)

        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationZ(Geometry.DegreeToRadian(-90))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        device.Transform.World = Matrix.Identity
        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationZ(Geometry.DegreeToRadian(-90))
        device.Transform.World *= Matrix.RotationY(Geometry.DegreeToRadian(90))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        device.Transform.World = Matrix.Identity
        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationZ(Geometry.DegreeToRadian(-90))
        device.Transform.World *= Matrix.RotationY(Geometry.DegreeToRadian(180))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        device.Transform.World = Matrix.Identity
        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationZ(Geometry.DegreeToRadian(-90))
        device.Transform.World *= Matrix.RotationY(Geometry.DegreeToRadian(270))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        device.Transform.World = Matrix.Identity
        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationX(Geometry.DegreeToRadian(-90))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        device.Transform.World = Matrix.Identity
        device.Transform.World *= Matrix.Translation(0, 0, 2)
        device.Transform.World *= Matrix.RotationX(Geometry.DegreeToRadian(90))
        device.Transform.World *= m
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, v)

        f.DrawText(Nothing, px & "|" & pz & "||" & akcx & "|" & akcz, 0, 0, Color.White)
    End Sub
    Sub key(e As KeyEventArgs)
        If dreh = 0 Then
            Select Case e.KeyCode
                Case Is = Keys.W
                    dreh = 1
                Case Is = Keys.S
                    dreh = 2
                Case Is = Keys.A
                    dreh = 3
                Case Is = Keys.D
                    dreh = 4
                Case Is = Keys.M
                    dreh = 5
                Case Is = Keys.Escape
                    dreh = 100
            End Select
        End If
    End Sub
    Sub drehdig(xa As Boolean, positiv As Boolean)
        If xa Then
            If positiv Then
                d -= speed
                m = Matrix.Identity
                m = Matrix.RotationZ(Geometry.DegreeToRadian(90 + d))
                If d2 = 1 Then
                    d += 1
                End If
                If d = 90 Or d = -90 Then
                    d = 0
                    dreh = 0
                    px += 4
                    cpx = px
                End If
                Dim x, y As Double
                y = Math.Sin(Geometry.DegreeToRadian(90 + d + 45)) * Math.Sqrt(8) - 2
                x = Math.Cos(Geometry.DegreeToRadian(90 + d + 45)) * Math.Sqrt(8) + 2
                m *= Matrix.Translation(x + px, y, pz)
                cpx = x + px
            Else
                d += speed
                m = Matrix.Identity
                m = Matrix.RotationZ(Geometry.DegreeToRadian(d))
                If d2 = 1 Then
                    d += 1
                End If
                If d = 90 Or d = -90 Then
                    d = 0
                    dreh = 0
                    px -= 4
                    cpx = px
                End If
                Dim x, y As Double
                y = Math.Sin(Geometry.DegreeToRadian(d + 45)) * Math.Sqrt(8) - 2
                x = Math.Cos(Geometry.DegreeToRadian(d + 45)) * Math.Sqrt(8) + 2
                m *= Matrix.Translation(x + px - 4, y, pz)
                cpx = x + px - 4
            End If
        Else
            If positiv Then
                d -= speed
                m = Matrix.Identity
                m = Matrix.RotationX(Geometry.DegreeToRadian(90 - d))
                If d2 = 1 Then
                    d += 1
                End If
                If d = 90 Or d = -90 Then
                    d = 0
                    dreh = 0
                    pz += 4
                    cpz = pz
                End If
                Dim x, y As Double
                y = Math.Sin(Geometry.DegreeToRadian(90 + d + 45)) * Math.Sqrt(8) - 2
                x = Math.Cos(Geometry.DegreeToRadian(90 + d + 45)) * Math.Sqrt(8) + 2
                m *= Matrix.Translation(px, y, x + pz)
                cpz = x + pz
            Else
                d += speed
                m = Matrix.Identity
                m = Matrix.RotationX(Geometry.DegreeToRadian(90 - d))
                If d2 = 1 Then
                    d += 1
                End If
                If d = 90 Or d = -90 Then
                    d = 0
                    dreh = 0
                    pz -= 4
                    cpz = pz
                End If
                Dim x, y As Double
                y = Math.Sin(Geometry.DegreeToRadian(d + 45)) * Math.Sqrt(8) - 2
                x = Math.Cos(Geometry.DegreeToRadian(d + 45)) * Math.Sqrt(8) + 2
                m *= Matrix.Translation(px, y, x + pz - 4)
                cpz = x + pz - 4
            End If
        End If


    End Sub
End Class