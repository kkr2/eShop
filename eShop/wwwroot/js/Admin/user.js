﻿var app = new Vue({
    el: '#app',
    data: {
        username:""
    },
    mounted() {
        
    },
    methods: {
        createUser() {
            axios.post("/users", { username: this.username })
                .then(res => {

                    
                })
                .catch(err => console.log(err))
        }
    }
})