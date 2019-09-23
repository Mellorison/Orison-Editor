using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Drawing;
using OrisonEditor.LevelData.Layers;
using System.Windows.Forms;
using System.Diagnostics;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.Windows
{
    public class EntitySelectionWindow : OrisonWindow
    {
        private const int WIDTH = 128;
        private const int TEXT_SPLIT = 56;
        private const int SPLIT_PAD = 1;

        private const int TITLE_WIDTH = TEXT_SPLIT - SPLIT_PAD;
        private const int CONTENT_X = TEXT_SPLIT + SPLIT_PAD;
        private const int CONTENT_WIDTH = WIDTH - TEXT_SPLIT - SPLIT_PAD;

        private List<Entity> selection;
        private Label positionLabel;
        private Label sizeLabel;

        public EntitySelectionWindow()
            : base(HorizontalSnap.Right, VerticalSnap.Bottom)
        {
            Name = "EntitySelectionWindow";
            Text = "Selection";
            ClientSize = new Size(WIDTH, 128);
            selection = new List<Entity>();
            onSelectionChanged();
            DoubleBuffered = true;

            //Init some of the labels
            {
                positionLabel = new Label();
                positionLabel.TextAlign = ContentAlignment.MiddleLeft;
                positionLabel.Bounds = new Rectangle(CONTENT_X, 96, CONTENT_WIDTH, 16);

                sizeLabel = new Label();
                sizeLabel.TextAlign = ContentAlignment.MiddleLeft;
            }

            //Events
            Orison.LayersWindow.OnLayerChanged += onLayerChanged;
        }

        public override bool ShouldBeVisible()
        {
            return Orison.LayersWindow.CurrentLayer is EntityLayer;
        }

        /*
         *  Selection API
         */
        public void SetSelection(Entity e)
        {
            selection.Clear();
            selection.Add(e);
            onSelectionChanged();
        }

        public void SetSelection(List<Entity> e)
        {
            selection.Clear();
            foreach (Entity ee in e)
                selection.Add(ee);
            onSelectionChanged();
        }

        public void AddToSelection(Entity e)
        {
            if (!selection.Contains(e))
                selection.Add(e);
            onSelectionChanged();
        }

        public void AddToSelection(List<Entity> e)
        {
            foreach (Entity ee in e)
            {
                if (!selection.Contains(ee))
                    selection.Add(ee);
            }
            onSelectionChanged();
        }

        public void RemoveFromSelection(Entity e)
        {
            selection.Remove(e);
            onSelectionChanged();
        }

        public void RemoveFromSelection(List<Entity> e)
        {
            foreach (Entity ee in e)
                selection.Remove(ee);
            onSelectionChanged();
        }

        public void ToggleSelection(List<Entity> e)
        {
            foreach (Entity ee in e)
            {
                if (selection.Contains(ee))
                    selection.Remove(ee);
                else
                    selection.Add(ee);
            }
            onSelectionChanged();
        }

        public void ClearSelection()
        {
            selection.Clear();
            onSelectionChanged();
        }

        public bool IsSelected(Entity e)
        {
            return selection.Contains(e);
        }

        public int AmountSelected
        {
            get { return selection.Count; }
        }

        public List<Entity> Selected
        {
            get { return new List<Entity>(selection); }
        }

        public void RefreshContents()
        {
            onSelectionChanged();
        }

        public void RefreshPosition()
        {
            if (selection.Count == 1)
                positionLabel.Text = "( " + selection[0].Position.X.ToString() + ", " + selection[0].Position.Y.ToString() + " )";
        }

        public void RefreshSize()
        {
            if (selection.Count == 1)
                sizeLabel.Text = selection[0].Size.Width.ToString() + " x " + selection[0].Size.Height.ToString();
        }

        /*
         *  Events
         */
        private void onSelectionChanged()
        {
            Controls.Clear();

            if (selection.Count == 0)
            {
                ClientSize = new Size(WIDTH, 108);

                //No selection label
                Label lbl = new Label();
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Bounds = new Rectangle(0, 0, WIDTH, 108);
                lbl.Text = "No\nSelection";
                Controls.Add(lbl);
            }
            else if (selection.Count == 1)
            {
                //Name label
                Label name = new Label();
                name.Font = new Font(name.Font, FontStyle.Bold);
                name.TextAlign = ContentAlignment.MiddleCenter;
                name.Bounds = new Rectangle(0, 0, WIDTH, 24);
                name.Text = selection[0].Definition.Name;
                Controls.Add(name);

                //Add the image
                EntitySelectionImage sel = new EntitySelectionImage(selection[0], WIDTH / 2 - 16, 24);
                Controls.Add(sel);

                //Entity ID
                {
                    Label id = new Label();
                    id.TextAlign = ContentAlignment.MiddleLeft;
                    id.Text = selection[0].ID.ToString();
                    id.Bounds = new Rectangle(CONTENT_X, 60, CONTENT_WIDTH, 16);
                    Controls.Add(id);

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = "ID:";
                    label.Bounds = new Rectangle(0, 60, TITLE_WIDTH, 16);
                    Controls.Add(label);
                }

                //Entity count
                {
                    Label count = new Label();
                    count.TextAlign = ContentAlignment.MiddleLeft;
                    count.Bounds = new Rectangle(CONTENT_X, 78, CONTENT_WIDTH, 16);
                    count.Text = ((EntityLayer)Orison.LayersWindow.CurrentLayer).Entities.Count(e => e.Definition == selection[0].Definition).ToString();
                    if (selection[0].Definition.Limit > 0)
                        count.Text += " / " + selection[0].Definition.Limit.ToString();
                    Controls.Add(count);

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = "Count:";
                    label.Bounds = new Rectangle(0, 78, TITLE_WIDTH, 16);
                    Controls.Add(label);
                }

                //Entity position
                {
                    RefreshPosition();
                    Controls.Add(positionLabel);

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = "Position:";
                    label.Bounds = new Rectangle(0, 96, TITLE_WIDTH, 16);
                    Controls.Add(label);
                }

                //Entity size    
                int yy = 114;
                if (selection[0].Definition.ResizableX || selection[0].Definition.ResizableY)
                {
                    sizeLabel.Bounds = new Rectangle(CONTENT_X, yy, CONTENT_WIDTH, 16);
                    RefreshSize();
                    Controls.Add(sizeLabel);

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = "Size:";
                    label.Bounds = new Rectangle(0, yy, TITLE_WIDTH, 16);
                    Controls.Add(label);

                    yy += 18;
                }

                //Entity angle
                if (selection[0].Definition.Rotatable)
                {
                    yy += 3;

                    TextBox angleTextBox = new TextBox();
                    angleTextBox.Bounds = new Rectangle(CONTENT_X, yy - 2, CONTENT_WIDTH - 20, 16);
                    angleTextBox.Text = selection[0].Angle.ToString();    
                    angleTextBox.LostFocus += delegate(object sender, EventArgs e) { if (selection.Count > 0) HandleAngleChange(angleTextBox); };
                    angleTextBox.KeyDown += delegate(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { HandleAngleChange(angleTextBox); Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Focus(); } };
                    Controls.Add(angleTextBox);

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = "Angle:";
                    label.Bounds = new Rectangle(0, yy, TITLE_WIDTH, 16);
                    Controls.Add(label);

                    yy += 18;
                }

                //Value editors
                if (selection[0].Values != null)
                {
                    yy += 8;
                    foreach (var v in selection[0].Values)
                    {
                        ValueEditor ed = v.Definition.GetInstanceEditor(v, 0, yy);
                        Controls.Add(ed);
                        yy += ed.Height;
                    }
                }

                ClientSize = new Size(ClientSize.Width, yy + 4);
            }
            else
            {
                ClientSize = new Size(ClientSize.Width, ((selection.Count - 1) / 4) * 32 + 32);

                for (int i = 0; i < selection.Count; i++)
                {
                    EntitySelectionImage e = new EntitySelectionImage(selection[i], (i % 4) * 32, (i / 4) * 32);
                    Controls.Add(e);
                }
            }

            Orison.MainWindow.FocusEditor();
        }

        private void HandleAngleChange(TextBox textBox)
        {
            float to = selection[0].Angle;
            OrisonParse.Parse(ref to, textBox);

            if (to != selection[0].Angle)
            {
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(new EntityRotateAction(selection[0].Layer, selection, to));
                textBox.Text = selection[0].Angle.ToString();
            }
        }

        private void onLayerChanged(LayerDefinition def, int index)
        {
            EditorVisible = def is EntityLayerDefinition;
        }
    }
}
