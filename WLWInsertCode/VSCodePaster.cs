using System;
using System.Windows.Forms;
using WindowsLive.Writer.Api;
using RtfToHtml;

namespace WLWInsertCode {

  [WriterPlugin("F85C3533-BC93-49e8-8273-4FA33D21EDCC", "PasteCodeFromVS")]
  [InsertableContentSource("Paste Code From VS")]
  public class VSCodePaster : ContentSource {

    public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content) {
      DialogResult result = DialogResult.OK;

      if (Clipboard.ContainsText(TextDataFormat.Rtf)) {
        string s = Clipboard.GetText(TextDataFormat.Rtf);
        string html = RtfParser.ParseRtf(s);
        content = String.Format("<div class=\"jmbcodeblock\"><pre>{0}{1}</pre></div>{0}", Environment.NewLine, html);
      }
      else {
        content = "Clipboard is empty of RTF text";
      }
      return result;
    }
  }
}
