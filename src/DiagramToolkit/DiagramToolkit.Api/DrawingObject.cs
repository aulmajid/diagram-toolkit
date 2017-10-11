﻿using DiagramToolkit.States;
using System;
using System.Diagnostics;
using System.Drawing;

namespace DiagramToolkit
{
    public abstract class DrawingObject : IVisitable
    {
        public Guid ID { get; set; }

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        public Color CurrentColor { get; set; }

        private DrawingState state;
        private Graphics graphics;

        public DrawingObject()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance()); //default initial state
            this.CurrentColor = Color.Black;
        }

        public abstract bool Add(DrawingObject obj);
        public abstract bool Remove(DrawingObject obj);
        
        public abstract bool Intersect(int xTest, int yTest);
        public abstract void Translate(int x, int y, int xAmount, int yAmount);

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }

        public virtual void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public virtual Graphics GetGraphics()
        {
            return this.graphics;
        }

        public void Select()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is selected.");
            this.state.Select(this);
        }

        public void Deselect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is deselected.");
            this.state.Deselect(this);
        }

        public abstract void Accept(IVisitor visitor);
    }
}
