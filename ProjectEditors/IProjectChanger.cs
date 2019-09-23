using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrisonEditor.ProjectEditors
{
    public interface IProjectChanger
    {
        void LoadFromProject(Project project);
    }
}
