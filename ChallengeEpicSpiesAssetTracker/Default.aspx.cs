using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Create empty arrays
            string[] assetName = new string[0];
            int[] electionsRigged = new int[0];
            int[] actsPerformed = new int[0];

            ViewState.Add("AssetName", assetName);
            ViewState.Add("ElectionsRigged", electionsRigged);
            ViewState.Add("ActsPerformed", actsPerformed);
        }
    }

    protected void addButton_Click(object sender, EventArgs e)
    {
        // Retrieve values from ViewState and cast it to arrays of appropriate type
        string[] assetName = (string[])ViewState["AssetName"];
        int[] electionsRigged = (int[])ViewState["ElectionsRigged"];
        int[] actsPerformed = (int[])ViewState["ActsPerformed"];

        // Establish variable for reuse
        int newLength = assetName.Length + 1;

        // Resize arrays
        Array.Resize(ref assetName, newLength);
        Array.Resize(ref electionsRigged, newLength);
        Array.Resize(ref actsPerformed, newLength);

        // Variable to grab newest index
        int newIndex = assetName.GetUpperBound(0);

        // Grabbing values that were entered into text boxes and storing them into array
        assetName[newIndex] = assetTextBox.Text;
        electionsRigged[newIndex] = int.Parse(electionTextBox.Text);
        actsPerformed[newIndex] = int.Parse(actsTextBox.Text);

        // Updating the ViewState with most recent added value in text boxes
        ViewState["AssetName"] = assetName;
        ViewState["ElectionsRigged"] = electionsRigged;
        ViewState["ActsPerformed"] = actsPerformed;
        

        resultLabel.Text = String.Format("Total Elections Rigged: {0}<br>Average Acts of Subterfuge per Asset {1:N2}<br>(Last Asset You Added: {2})",
            electionsRigged.Sum(),
            actsPerformed.Average(),
            assetName.Last());
    }
}