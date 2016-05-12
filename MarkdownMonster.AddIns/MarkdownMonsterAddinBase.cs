﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownMonster.AddIns
{
    public class MarkdownMonsterAddin
    {
        public AppModel Model { get; set; }

        /// <summary>
        /// List of menu items that are used to extend MM
        /// Menu items get attached to the Addin menu and fire
        /// when clicked.        
        /// </summary>
        public List<AddInMenuItem> MenuItems { get; set;  }

        public virtual void OnApplicationStart()
        {
                        
        }

        public virtual void OnApplicationShutdown()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool OnBeforeOpenFile()
        {
            return true;
        }

        public virtual void  OnAfterOpenFile()
        {            
        }

        public virtual bool OnBeforeSaveFile()
        {
            return true;
        }

        public virtual void OnAfterSaveFile()
        {
            
        }

        public virtual void OnDocumentActivated()
        {
                        
        }

        /// <summary>
        /// Retrieve an instance of the MarkdownEditor control from the
        /// active window. This instance wraps the editor and provides
        /// a number of methods for getting access to the editor document
        /// </summary>
        /// <returns></returns>
        public MarkdownDocumentEditor GetMarkdownEditor()
        {
            return Model.Window.GetActiveMarkdownEditor();
        }

        /// <summary>
        /// Returns the Markdown document instance which has access
        /// to the actual document that ends up being saved. This
        /// includes the content and the IsDirty flag. Note that
        /// content is updated only after save operations. If you need
        /// to update live content it's best to inject directly into
        /// the edtor using the GetSelectedText() and SetSelectedText().
        /// </summary>
        /// <returns></returns>
        public MarkdownDocument GetMarkdownDocument()
        {
            var editor =  Model.Window.GetActiveMarkdownEditor();
            return editor?.MarkdownDocument;
        }

        /// <summary>
        /// Returns the active live markdown text from the editor
        /// </summary>
        /// <returns></returns>
        public string GetMarkdown()
        {
            var editor = this.Model.Window.GetActiveMarkdownEditor();
            return editor?.GetMarkdown();
        }


        /// <summary>
        /// Sets all the text in the markdown editor
        /// </summary>
        /// <param name="markdownText"></param>
        public void SetMarkdown(string markdownText)
        {
            var editor = this.Model.Window.GetActiveMarkdownEditor();
            editor?.SetMarkdown(markdownText);
        }


        /// <summary>
        /// Gets the active selection from the editor
        /// </summary>
        /// <returns></returns>
        public string GetSelection()
        {
            var editor = this.Model.Window.GetActiveMarkdownEditor();
            return editor?.AceEditor.getselection(false);
        }


        /// <summary>
        /// Sets the active selection from the editor
        /// </summary>
        /// <param name="text"></param>
        public void SetSelection(string text)
        {
            var editor = this.Model.Window.GetActiveMarkdownEditor();
            editor?.AceEditor.setselection(text);

            editor.MarkdownDocument.CurrentText = editor.GetMarkdown();
            Model.Window.PreviewMarkdown(editor, true);
        }

        /// <summary>
        /// Commands are added to the tag
        /// </summary>
        /// <param name="cmd"></param>
        public void ExecuteEditCommand(string cmd)
        {
            
        }        
    }
}