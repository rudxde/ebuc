Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class Mob
    Public Class Defauld
        Dim v(5) As CustomVertex.PositionNormalTextured
        Dim tex As Texture
        Dim cpx, cpz As Decimal
        Dim m As Matrix
        Public dreh As Byte
        Public px As Integer
        Public pz As Integer
        Dim d, d2 As Decimal
        Public speed As Decimal
        Public akcx, akcz As Integer
        Dim mes As Mesh
        Public sicht As Byte
        Public gw As Boolean
        Dim gwt As Texture
        Sub load(device As Device)
            v(0) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = -2, .Z = 0, .Tv = 0, .Tu = 0}
            v(1) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = 2, .Z = 0, .Tv = 0, .Tu = 1}
            v(2) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = 0, .Tv = 1, .Tu = 0}
            v(3) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = 2, .Z = 0, .Tv = 1, .Tu = 1}
            v(4) = New CustomVertex.PositionNormalTextured With {.X = -2, .Y = 2, .Z = 0, .Tv = 0, .Tu = 1}
            v(5) = New CustomVertex.PositionNormalTextured With {.X = 2, .Y = -2, .Z = 0, .Tv = 1, .Tu = 0}
            tex = TextureLoader.FromFile(device, "REcources/bboden1.png")
            gwt = TextureLoader.FromFile(device, "REcources/cube.png")
        End Sub
        Sub draw(device As Device, ppx As Integer, ppz As Integer)
            Dim ax, az As Integer
            ax = px
            az = pz
            ax = ax - (ppx + (akcx * 64))
            az = az - (ppz + (akcz * 64))
            ax = ax * ax
            az = az * az
            If Math.Sqrt(ax + az) <= sicht Then
                If dreh = 0 Then
                    If ppx + (akcx * 64) = px Then
                        If ppz + (akcz * 64) > pz Then
                            dreh = 3
                        Else
                            dreh = 4
                        End If
                    Else
                        If ppx + (akcx * 64) > px Then
                            dreh = 1
                        Else
                            dreh = 2
                        End If
                    End If
                End If
            End If
            Select Case dreh
                Case Is = 1
                    drehdig(True, True)
                Case Is = 2
                    drehdig(True, False)
                Case Is = 3
                    drehdig(False, True)
                Case Is = 4
                    drehdig(False, False)
                Case Else
                    m = Matrix.Identity
                    m *= Matrix.Translation(px, 0, pz)
            End Select
            m *= Matrix.Translation(akcx * -64, 0, akcz * -64)

            device.VertexFormat = CustomVertex.PositionNormalTextured.Format
            device.Transform.World = Matrix.Identity
            If gw Then
                device.SetTexture(0, gwt)
            Else
                device.SetTexture(0, tex)
            End If

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
                    If d <= -90 Then
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
                    If d >= 90 Then
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
                    If d <= -90 Then
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
                    If d >= 90 Then
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
End Class
