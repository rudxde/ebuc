Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class Main
    Dim device As Device
    Dim dxd As New directx
    Public elementmanager As New elementmanager
    Dim pp As New PresentParameters
    Public Sub New(ByVal Form As Form)
        Try
            Form.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Form.WindowState = FormWindowState.Maximized
            pp.Windowed = True
            pp.SwapEffect = SwapEffect.Discard
            pp.EnableAutoDepthStencil = True
            pp.AutoDepthStencilFormat = DepthFormat.D24S8
            device = New Device(0, DeviceType.Hardware, Form, CreateFlags.SoftwareVertexProcessing, pp)
            elementmanager.load(device)
            device.RenderState.Lighting = False
            device.RenderState.CullMode = 2
            device.RenderState.ZBufferEnable = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub frame()
        device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Color.Black, 1, 1)
        device.BeginScene()
        'Rendern
        device.Transform.Projection = Matrix.PerspectiveFovLH(Geometry.DegreeToRadian(45), pp.BackBufferWidth / pp.BackBufferHeight, 0.001, 500)
        elementmanager.draw(device)
        device.EndScene()
        device.Present()
    End Sub
End Class