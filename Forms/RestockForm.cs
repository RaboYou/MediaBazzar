using MediaBazaar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazzar.Forms
{
    public partial class RestockForm : Form
    {

        private readonly SQLConStockRequestsHandling conStockHandling = new SQLConStockRequestsHandling();

        public RestockForm()
        {
            InitializeComponent();
            LoadRestocks();
        }

        private List<Restock> _activerestocks = new List<Restock>();
        private List<Restock> _confirmedrestocks = new List<Restock>();
        private Dictionary<int, string> restocksNamesToId = new Dictionary<int, string>();
        private int hiddenId;


        private void LoadRestocks()
        {
            restocksNamesToId.Clear();
            lbRestocks.Items.Clear();
            lbConfirmedRestocks.Items.Clear();
            _activerestocks = conStockHandling.GetAllRestockRequests();
            _confirmedrestocks = conStockHandling.GetAllConfirmedRestockRequests();
            foreach (var restock in _activerestocks)
            {
                restocksNamesToId.Add(restock.orderrequestId, restock.productName);
                lbRestocks.Items.Add($"{restock.productName}, {restock.orderrequestId}");
            }
            foreach(var restock in _confirmedrestocks)
            {
                restocksNamesToId.Add(restock.orderrequestId, restock.productName);
                lbConfirmedRestocks.Items.Add($"{restock.productName}, {restock.orderrequestId}");
            }
        }

        private void lbRestocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRestocks.SelectedItem.Equals(null)) { }
            else
            {
                Restock selectedRestock = null;
                foreach (var item in _activerestocks)
                {
                    string[] name = lbRestocks.SelectedItem.ToString().Split(',');
                    string orderCompare = "";
                    foreach (string namePart in name)
                    {
                        orderCompare = namePart.Trim();
                    }
                    int orderId = Convert.ToInt32(orderCompare);
                    if (item.orderrequestId == orderId)
                    {
                        selectedRestock = item;
                    }
                }
                if (selectedRestock != null)
                {
                    hiddenId = selectedRestock.Id;
                    lblAcceptProductName.Text = selectedRestock.productName;
                    lblAcceptBuyPrice.Text = selectedRestock.buyPrice.ToString();
                    lblAcceptSellPrice.Text = selectedRestock.sellPrice.ToString();
                    lblAcceptCategory.Text = selectedRestock.category.ToString();
                    lblAcceptQuantity.Text = selectedRestock.quantity.ToString();
                }
            }
        }

        private void btnSearchRestocks_Click(object sender, EventArgs e)
        {
            lbRestocks.Items.Clear();

            foreach (var restock in _activerestocks)
            {
                if ($"{restock.orderrequestId} {restock.productName}".IndexOf(tbSearchRestocks.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lbRestocks.Items.Add($"{restock.orderrequestId} {restock.productName}");
                }
            }
        }

        private void btnAcceptRestocks_Click(object sender, EventArgs e)
        {
            
            foreach (var item in _activerestocks)
            {
                string[] name = lbRestocks.SelectedItem.ToString().Split(',');
                string orderCompare = "";
                foreach (string namePart in name)
                {
                    orderCompare = namePart.Trim();
                }
                int orderId = Convert.ToInt32(orderCompare);
                if (item.orderrequestId == orderId)
                {
                    item.IsOpen = false;
                }
                conStockHandling.UpdateRestock(item);
            }
            LoadRestocks();
        }

        private void lbConfirmedRestocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbConfirmedRestocks.SelectedItem.Equals(null)) { }
            else
            {
                Restock selectedRestock = null;
                foreach (var item in _confirmedrestocks)
                {
                    string[] name = lbConfirmedRestocks.SelectedItem.ToString().Split(',');
                    string orderCompare = "";
                    foreach (string namePart in name)
                    {
                        orderCompare = namePart.Trim();
                    }
                    int orderId = Convert.ToInt32(orderCompare);
                    if (item.orderrequestId == orderId)
                    {
                        selectedRestock = item;
                    }
                }
                if (selectedRestock != null)
                {
                    hiddenId = selectedRestock.Id;
                    lblAcceptProductName.Text = selectedRestock.productName;
                    lblAcceptBuyPrice.Text = selectedRestock.buyPrice.ToString();
                    lblAcceptSellPrice.Text = selectedRestock.sellPrice.ToString();
                    lblAcceptCategory.Text = selectedRestock.category.ToString();
                    lblAcceptQuantity.Text = selectedRestock.quantity.ToString();
                }
            }
        }

        private void btnSearchConfirmedRestocks_Click(object sender, EventArgs e)
        {
            lbConfirmedRestocks.Items.Clear();

            foreach (var restock in _confirmedrestocks)
            {
                if ($"{restock.orderrequestId} {restock.productName}".IndexOf(tbSearchRestocks.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lbRestocks.Items.Add($"{restock.orderrequestId} {restock.productName}");
                }
            }
        }
    }
}
