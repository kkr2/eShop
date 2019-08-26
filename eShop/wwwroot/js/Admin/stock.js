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
            axios.get("/Admin/stocks")
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
            axios.post("/Admin/stocks", this.newStock)
                .then(res => {
                    console.log(res);
                    sel = this.selectedProduct
                    sel.stock.push(res.data);
                })
                .catch(err => console.log(err))
        },
        updateStock() {

        },
        deleteStock() {

        }
    }
})