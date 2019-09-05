var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            ProductId: 0,
            Description: "Size",
            Qty: 10
        }
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            axios.get("/stocks")
                .then(res => {

                    this.products = res.data;
                })
                .catch(err => console.log(err))
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.ProductId = product.id;
        },
        addStock() {
            axios.post("/stocks", this.newStock)
                .then(res => {
                    console.log(res);
                    sel = this.selectedProduct
                    sel.stock.push(res.data);
                })
                .catch(err => console.log(err))
        },
        updateStock() {
            var vm = this.selectedProduct.stock.map(x => {
                return {
                    Id: x.id,
                    Description: x.description,
                    Qty: x.qty,
                    ProductId: this.selectedProduct.id
                }
            })
            axios.put("/stocks", {
                stock: vm
            })

                .then(res => {
                    
                    
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => console.log(err))
        },
        deleteStock(id,index) {
            axios.delete("/stocks/"+id)
                .then(res => {
                    
                    this.selectedProduct.stock.splice(index,1);
                })
                .catch(err => console.log(err))
        }
    }
})