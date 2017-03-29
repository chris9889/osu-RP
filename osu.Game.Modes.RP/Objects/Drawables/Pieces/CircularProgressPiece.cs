using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace osu.Game.Modes.RP.Objects.Drawables.Pieces
{
    /// <summary>
    /// this code is from osu!stream_desktop and will be remove before public in github
    /// </summary>
    class CircularProgressPiece : Drawable
    {
        public float Progress;
        public float Radius;
        public bool EvenShading;

        int parts = 48;
#if !NO_PIN_SUPPORT
        float[] vertices;
        float[] colours;
#endif

        GCHandle handle_vertices;
        GCHandle handle_colours;

        IntPtr handle_vertices_pointer;
        IntPtr handle_colours_pointer;

        public CircularProgressPiece(Vector2 position, float radius, Color4 colour)
        {
            //parts = GameBase.IsSlowDevice ? 36 : 48;
            //AlwaysDraw = alwaysDraw;
            //Alpha = alwaysDraw ? 1 : 0;
            //DrawDepth = drawDepth;
            Alpha = 1;
            Position = position;
            Radius = radius;
            Colour = colour;
            Depth = 0;
            //Field = FieldTypes.Standard;
#if !NO_PIN_SUPPORT
            vertices = new float[parts * 2 + 2];
            colours = new float[parts * 4 + 4];


            handle_vertices = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            handle_colours = GCHandle.Alloc(colours, GCHandleType.Pinned);

            handle_vertices_pointer = handle_vertices.AddrOfPinnedObject();
            handle_colours_pointer = handle_colours.AddrOfPinnedObject();
#else
            handle_vertices_pointer = Marshal.AllocHGlobal((parts * 2 + 2) * sizeof(float));
            handle_colours_pointer = Marshal.AllocHGlobal((parts * 4 + 4) * sizeof(float));
#endif
        }

        public void Dispose()
        {
#if !NO_PIN_SUPPORT
            if (handle_colours.IsAllocated)
            {
                handle_colours.Free();
                handle_vertices.Free();
            }
#else
            Marshal.FreeHGlobal(handle_vertices_pointer);
            Marshal.FreeHGlobal(handle_colours_pointer);
#endif

            base.Dispose();
        }

        public bool UpdateProgress()
        {
            if (true)//base.Draw())
            {

                Color4 c = Colour;

                float startAngle = (float)(-MathHelper.Pi / 2);
                float cappedProgress = Math.Max(0, Math.Min(1, Progress));

                float endAngle = (float)(cappedProgress * MathHelper.Pi * 2f + startAngle);

                float da = (endAngle - startAngle) / (parts - 1);

                float radius = Radius ;//* FieldScale.X;
                Vector2 pos = Position;


                unsafe
                {
                    float* vertices = (float*)handle_vertices_pointer.ToPointer();
                    float* colours = (float*)handle_colours_pointer.ToPointer();

                    vertices[0] = pos.X;
                    vertices[1] = pos.Y;

                    colours[0] = c.R;
                    colours[1] = c.G;
                    colours[2] = c.B;
                    colours[3] = c.A * Progress;

                    float a = startAngle;
                    for (int v = 1; v <= parts; v++)
                    {
                        vertices[v * 2] = (float)(pos.X + Math.Cos(a) * radius);
                        vertices[v * 2 + 1] = (float)(pos.Y + Math.Sin(a) * radius);
                        a += da;

                        colours[v * 4] = c.R;
                        colours[v * 4 + 1] = c.G;
                        colours[v * 4 + 2] = c.B;
                        colours[v * 4 + 3] = c.A * (EvenShading ? 0.6f : (0.2f + 0.4f * ((float)v / parts)));
                    }
                }
                GL.EnableClientState(ArrayCap.ColorArray);

                GL.VertexPointer(2, VertexPointerType.Float, 0, handle_vertices_pointer);
                GL.ColorPointer(4, ColorPointerType.Float, 0, handle_colours_pointer);

                GL.DrawArrays(BeginMode.TriangleFan, 0, parts + 1);

                GL.DisableClientState(ArrayCap.ColorArray);

                return true;
            }

            return false;

        }
    }
}
