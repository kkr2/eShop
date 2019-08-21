﻿var app = new Vue({
    el: '#app',
    data: {
        
        objectIndex:0 ,
        productModel: {
            id:0,
            name: "Product name",
            description: "Product Description",
            value:1.00
        },
        products:[]
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        createProduct() {
            axios.post("Admin/products", this.productModel)
                .then(res => {
                    this.products.push(res.data);
                 
                })
                .catch(err => console.log(err))
        },
        

        getProducts() {
            axios.get("Admin/products")
                .then( res => {
                    
                    this.products = res.data;
                })
                .catch(err => console.log(err))
        },
        getProduct(id) {
            axios.get('Admin/products/'+id)
                .then(res => {
                    
                    var product = res.data;
                    this.productModel = {
                        id:product.id,
                        name: product.name,
                        description: product.description,
                        value: product.value

                    };
                })
                .catch(err => console.log(err))
        },
        editProduct(id,index) {
            this.objectIndex = index;
            
            this.getProduct(id);
            
        },
        updateProduct() {
            axios.put("Admin/products", this.productModel)
                .then(res => {
                    
                    this.products.splice(this.objectIndex, 1, res.data);

                })
                .catch(err => console.log(err))
        },
        deleteProduct(id, index) {
            axios.delete("Admin/products/" + id)
                .then(res => {
                    
                    this.products.splice(index, 1);
                })
                .catch(err => console.log(err))
        }

        
    }
});