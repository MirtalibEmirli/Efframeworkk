using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Eftaskhome1.Commands;
using Eftaskhome1.Data;
using Eftaskhome1.Models;
using Microsoft.EntityFrameworkCore;

namespace Eftaskhome1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly AppDbContxet appDb;
        private ObservableCollection<Product> productsObs;

        public ObservableCollection<Product> ProductsObs
        {
            get => productsObs;
            set
            {
                productsObs = value;
                OnPropertyChanged(nameof(ProductsObs));
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private string productName;
        public string ProductName
        {
            get => productName;
            set
            {
                productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string desc;
        public string Desc
        {
            get => desc;
            set
            {
                desc = value;
                OnPropertyChanged(nameof(Desc));
            }
        }

        private int price;
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public RelayCommand AddCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            appDb = new AppDbContxet();
            Categories = appDb.Category.ToList();
            ProductsObs = new ObservableCollection<Product>();
            DataContext = this;
            AddCommand = new RelayCommand(addProduct);
        }

        private void addProduct(object obj)
        {
            try
            {
                var product = new Product()
                {
                    PName = ProductName,
                    Description = Desc,
                    CategoryId = SelectedCategory.Id,
                    Price = Price
                };

                appDb.Product.Add(product);
                appDb.SaveChanges();

                ProductsObs.Add(new Product()
                {
                    PName = ProductName,
                    Description = Desc,
                    Category = SelectedCategory,
                    Price = Price
                });

                MessageBox.Show("Product added successfully!");
            }
            catch (Exception)
            {
                MessageBox.Show("Please ensure all fields are filled out correctly and constraints are met.");
            }
            finally
            {
                ProductName = string.Empty;
                Desc = string.Empty;
                SelectedCategory = null;
                Price = 0;
            }
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            var products = appDb.Product.Include(c => c.Category).ToList();
            foreach (var product in products)
            {
                ProductsObs.Add(new Product
                {
                    Id = product.Id,
                    PName = product.PName,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Category = product.Category
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
