using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add(1);
            dgv.Rows[dgv.Rows.Count - 1].Cells[0].Value = txtKey.Text;
            dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value = txtControl.Text;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String code = "";
            code +="-------------------Save-------------" +"\n";
            code += "List<PostData> PostDataList = new List<PostData>();" + "\n";
            code += "PostDataList.Add(new PostData(\"cmd\", \""+txtTableName.Text+"_Save" +"\"));" + "\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "PostDataList.Add(new PostData(\""+dgv.Rows[i].Cells[0].Value.ToString()+"\", "+ dgv.Rows[i].Cells[1].Value.ToString() + "));" + "\n";
            }
            
            code += "string xxx = GlobleFunctions.getDataFromWeb(PostDataList);" + "\n";
            code += "MessageBox.Show(xxx);" + "\n";
            code += " Form1_Load(sender, e);" + "\n";

           
            code += "-------------------Save-------------" + "\n";


            code += "-------------------Update-------------" + "\n";
            code += "List<PostData> PostDataList = new List<PostData>();" + "\n";
            code += "PostDataList.Add(new PostData(\"cmd\", \"" + txtTableName.Text + "_Update" + "\"));" + "\n";

            code += "PostDataList.Add(new PostData(\"id\", myid.ToString()));" + "\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "PostDataList.Add(new PostData(\"" + dgv.Rows[i].Cells[0].Value.ToString() + "\", " + dgv.Rows[i].Cells[1].Value.ToString() + "));" + "\n";
            }

            code += "string xxx = GlobleFunctions.getDataFromWeb(PostDataList);" + "\n";
            code += "MessageBox.Show(xxx);" + "\n";
            code += " Form1_Load(sender, e);" + "\n";
            code += "-------------------Update-------------" + "\n";


            code += "-------------------Delete-------------" + "\n";
            code += "List<PostData> PostDataList = new List<PostData>();" + "\n";
            code += "PostDataList.Add(new PostData(\"cmd\", \"" + txtTableName.Text + "_Delete" + "\"));" + "\n";

            code += "PostDataList.Add(new PostData(\"id\", myid.ToString()));" + "\n";
            

            code += "string xxx = GlobleFunctions.getDataFromWeb(PostDataList);" + "\n";
            code += "MessageBox.Show(xxx);" + "\n";
            code += " Form1_Load(sender, e);" + "\n";
            code += "-------------------Delete-------------" + "\n";


            code += "-------------------LoadData-------------" + "\n";
            code += "List<PostData> PostDataList = new List<PostData>();" + "\n";
            code += "PostDataList.Add(new PostData(\"cmd\", \""+txtTableName.Text+"_getAllData\"));" + "\n";


            code += "string xxx = GlobleFunctions.getDataFromWeb(PostDataList);" + "\n";
            code += "DataTable dt = new DataTable();" + "\n";
            code += "dt = GlobleFunctions.JosnToDataTable(xxx);" + "\n";
            code += "dgv.DataSource = dt;" + "\n";

            code += "dgv.Columns[0].Visible = false;" + "\n";


            code += "-------------------LoadData-------------" + "\n";

            code += "-------------------DGV_ClickEvent-------------" + "\n";

            code += "int cr = dgv.CurrentRow.Index;" + "\n";
            code += "myid = Convert.ToInt16(dgv.Rows[cr].Cells[0].Value.ToString());" + "\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += dgv.Rows[i].Cells[1].Value.ToString() + " = dgv.Rows[cr].Cells["+ Convert.ToString(i+2) +"].Value.ToString();"+ "\n";
            }
        
            code += "-------------------DGV_ClickEvent-------------" + "\n";



            rtChsarp.Text = code;
            code = "";

            code += "//-------------------php_save-------------" + "\n";
            code += "if($cmd===\""+txtTableName.Text+ "_Save\")" + "\n";
            code += "{" + "\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "\t$"+dgv.Rows[i].Cells[0].Value.ToString()+ "=$_POST[\""+ dgv.Rows[i].Cells[0].Value.ToString() + "\"];" + "\n";
            }

            code += "\t$sql=\"INSERT INTO `"+txtTableName.Text+"` values(null, " ;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "'$"+ dgv.Rows[i].Cells[0].Value.ToString() + "',";
            }
            code += ")\";" + "\n";
            code += "\t$result= mysqli_query($conn,$sql);" + "\n";
            code += "\t\tif($result)" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '"+ txtTableName.Text+ " Added successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "\t\telse" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '" + txtTableName.Text + " Not Added successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "}" + "\n";
            code += "//-------------------php_save-------------" + "\n";


            code += "//-------------------php_update-------------" + "\n";
            code += "if($cmd===\"" + txtTableName.Text + "_Update\")" + "\n";
            code += "{" + "\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "\t$" + dgv.Rows[i].Cells[0].Value.ToString() + "=$_POST[\"" + dgv.Rows[i].Cells[0].Value.ToString() + "\"];" + "\n";
            }

            code += "$id=$_POST[\"id\"];" + "\n";
            code += "\t$sql=\"update `" + txtTableName.Text + "`  set ";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += dgv.Rows[i].Cells[0].Value.ToString()+" ='$" + dgv.Rows[i].Cells[0].Value.ToString() + "' ,";
            }
            code += " where id =$id\";" + "\n";
            code += "\t$result= mysqli_query($conn,$sql);" + "\n";
            code += "\t\tif($result)" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '" + txtTableName.Text + " Update successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "\t\telse" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '" + txtTableName.Text + " Not Update successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "}" + "\n";
            code += "//-------------------php_update-------------" + "\n";

            code += "//-------------------php_delete-------------" + "\n";
            code += "if($cmd===\"" + txtTableName.Text + "_Delete\")" + "\n";
            code += "{" + "\n";
            
            code += "$id=$_POST[\"id\"];" + "\n";
            code += "\t$sql=\"delete from  `" + txtTableName.Text + "` ";
            
            code += "where id =$id\";" + "\n";
            code += "\t$result= mysqli_query($conn,$sql);" + "\n";
            code += "\t\tif($result)" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '" + txtTableName.Text + " Delete successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "\t\telse" + "\n";
            code += "\t\t{" + "\n";
            code += "\t\t\t$msgJson = array(" + "\n";
            code += "\t\t\t\"msg\" => '" + txtTableName.Text + " Not Delete successfully '" + "\n";
            code += "\t\t\t);" + "\n";
            code += "\t\t\t$msgJson = json_encode($msgJson);" + "\n";
            code += "\t\t\techo \"$msgJson\";" + "\n";
            code += "\t\t}" + "\n";
            code += "}" + "\n";
            code += "//-------------------php_delete-------------" + "\n";




            code += "//-------------------php_getAllData-------------" + "\n";
            code += "if($cmd===\"" + txtTableName.Text + "_getAllData\")" + "\n";
            code += "{" + "\n";

            code += "\t$sql = \"SELECT* FROM "+txtTableName.Text  +"\";" + "\n";
            code += "\t$result = mysqli_query($conn , $sql);" + "\n";
            code += "\t$arr1 = array();" + "\n";
            code += "\t$i=1;" + "\n";
            code += "\twhile ($row = mysqli_fetch_array($result))" + "\n";
            code += "\t{" + "\n";
            code += "\t\t $msgDetails = array(" + "\n";
            code += "\t\t\t\"id\" => $row[0]," + "\n";

            code += "\t\t\t\"Sr. No.\" => $i," + "\n";


            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                code += "\t\t\t\""+ dgv.Rows[i].Cells[0].Value.ToString() + "\" => $row["+Convert.ToString(i+1) +"]," + "\n";
            }
            code += "\t\t\t" + "\n";

            code += "\t\t);" + "\n";
            code += "\t\tarray_push($arr1, $msgDetails);" + "\n";

            code += "\t\t$i++;" + "\n";

            code += "\t}" + "\n";

            code += "\t$output = array(" + "\n";
            code += "\t\""+ txtTableName.Text+ "_array" + "\" => $arr1" + "\n";
            code += "\t);" + "\n";
            code += "\t$output = json_encode($output);" + "\n";
            code += "\techo \"$output\";" + "\n";



            code += "}" + "\n";
            code += "//-------------------php_getAllData-------------" + "\n";


            rtPhp.Text = code;

        }
    }
}
