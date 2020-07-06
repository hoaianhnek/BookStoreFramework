var shoppingCartItems = [];//mảng phần tử bỏ vào giỏ

//sự kiện click vào button add to cart
$(document).ready(function(){
    $('.add-to-cart>a').click(function(){
        var button = $(this);
        var id = button.attr('id');//id sp
        var name = button.attr('data-name'); //ten sp
        var price = button.attr('data-price');//gia sp
        var quantity = 1;
        var numberDis = button.attr('data-number');
        var image = button.attr('data-image');
        var priceDis = price - price*numberDis/100;
        var items = {
            id: id,
            image: image,
            name: name,
            priceNotDis: price,
            price: priceDis,
            quantity: quantity
        };
        var exists = false;
        if(shoppingCartItems.length>0) {
            $.each(shoppingCartItems, function(index,value) {
                if(value.id == items.id) {
                    value.quantity++;
                    exists = true;
                    return false;
                }
            });
        }
        if(!exists) {
            shoppingCartItems.push(items);
        }
    
        sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
        Swal.fire({
            title: 'Thêm sản phẩm thành công!',
            icon: 'success',
            confirmButtonText: 'OK'
          });
        displayShoppingCartItems();
    });
    $('.addcart').click(function() {
        var button = $(this);
        var id = button.attr('data-id');//id sp
        var name = button.attr('data-name'); //ten sp
        var price = button.attr('data-price');//gia sp
        var quantity = $('.quantity-product input').val();
        var numberDis = button.attr('data-number');
        var image = button.attr('data-image');
        var priceDis = price - price*numberDis/100;
        var items = {
            id: id,
            image: image,
            name: name,
            priceNotDis: price,
            price: priceDis,
            quantity: quantity
        };
        var exists = false;
        if(shoppingCartItems.length>0) {
            $.each(shoppingCartItems, function(index,value) {
                if(value.id == items.id) {
                    value.quantity = (value.quantity*10 + items.quantity*10)/10;
                    exists = true;
                    return false;
                }
            });
        }
        if(!exists) {
            shoppingCartItems.push(items);
        }
    
        sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
        Swal.fire({
            title: 'Thêm sản phẩm thành công!',
            icon: 'success',
            confirmButtonText: 'OK'
          });
        displayShoppingCartItems();
    });
});

function displayShoppingCartItems() {
    if(sessionStorage['shopping-cart-items'] != null) {
        shoppingCartItems = JSON.parse(sessionStorage['shopping-cart-items'].toString());
        $("#cartne").html("");
        var total = 0;
        var lengcart = 0;
        $.each(shoppingCartItems, function(index,item) {
            var htmlString = "";
            htmlString += "<ul> ";
            htmlString += "<li class='mini-cart'>";
            htmlString += "<a id='del-cart' onClick='delCart()' data-idbook='"+item.id+"'><i class='fas fa-trash-alt'></i></a>";
            htmlString += '<figure><img src="../../images/'+item.image+'"></figure>';
            htmlString += '<div>';
            htmlString += '<a href="#">'+item.name+'</a>';
            htmlString += '<span>'+item.quantity+'x $'+item.price+'</span>';
            htmlString += '</div> </li>';
            total += item.quantity*item.price;
            lengcart++;
            $("#cartne").append(htmlString);
        });
        var html = "";
        html += "<div id='cartne'>";
        html += "<div class='total-minicart d-flex justify-content-between'>";
        html += "<strong>Tổng:</strong>"
        html += "<span>$"+total+"</span>";
        html += "</div>";
        html += "<div class='view-minicart'> <a href='../../Home/Cart'>Xem giỏ hàng</a> </div>";
        html += "</div>";
        $("#cartne").append(html);
        $("#lengcart").html(lengcart);
    }
}

function delCart() {
    var id =$('#del-cart').attr('data-idbook');
    for(var i=0;i<shoppingCartItems.length;i++) {
        if(shoppingCartItems[i].id == id) {
            Swal.fire({
                title: 'Xóa sản phẩm thành công!',
                icon: 'success',
                confirmButtonText: 'OK'
              });
            shoppingCartItems.splice(i,1);
        }
    }
    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
    displayShoppingCartItems();
}
//display shopping cart
function displayShopping() {
    if(sessionStorage['shopping-cart-items'] != null) { 
        shoppingCartItems = JSON.parse(sessionStorage['shopping-cart-items'].toString());
        var total = 0;
        var lengcart = 0;
        $('.content-cart').html("");
        $.each(shoppingCartItems, function(index,item) { 
            var htmlString = "";
            htmlString += '<div class="row shopping-cart"> <div class="col-xs-3">';
            htmlString += '<img src="../../images/'+item.image+'"/></div>';
            htmlString += '<div class="col"> <div class="box-info-product">';
            htmlString += '<p class="title">'+item.name+'</p> <div class="action">';
            htmlString += '<a onclick= "delcartShop(this)" data-idbook ="'+item.id+'"> Xóa </a> </div> </div> <div class="box-price">';
            if(item.price == item.priceNotDis) {
                htmlString += '<span class="price-now">'+item.price+'$</span> </div>';
                
            } else {
                htmlString += '<span class="price-now">'+item.price+'$</span>';
                htmlString += '<span class="price-notdis">'+item.priceNotDis+'$</span> </div>';
            }
            
            htmlString += '<div class="box-quantity"> <div class="input-group">'+
                '<span class="input-group-btn"> <button data-idbook ="'+item.id+'" onclick = "minusQuantity(this)" class="btn btn-default" type="button">-</button>'+
                '</span> <input type="tel" class="form-control" value="'+item.quantity+'" min="0">'+
                '<span class="input-group-btn"><button data-idbook ="'+item.id+'" onclick="addQuantity(this)" class="btn btn-default" type="button">+</button></span></div></div>';
            htmlString += '<div class="box-sumprice">'+item.price*item.quantity+'$</div>';
            htmlString += '</div></div> <br>';
            $('.content-cart').append(htmlString);
            lengcart++;
            total += item.price*item.quantity;
        });
        $(".page-content-cart .title> span").html(lengcart);
        var html = "";
        html += '<div class="d-flex justify-content-end container-cart-product-pay pr-5 pt-5">';
        html += '<span class="mr-4">TỔNG TIỀN</span>';
        html += '<span class="ml-4">'+total+'$</span> </div>';
        $('.content-cart').append(html);
    }
}
// nút xóa sản phẩm
function delcartShop(ele) {
    var id = $(ele).attr("data-idbook");
    for(var i=0; i<shoppingCartItems.length;i++) {
        if(shoppingCartItems[i].id == id) {
            Swal.fire({
                title: 'Xóa sản phẩm thành công!',
                icon: 'success',
                confirmButtonText: 'OK'
              });
            shoppingCartItems.splice(i,1);
        }
    }
    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
    displayShopping();
    displayShoppingCartItems();
}
//nút cộng quantity
function addQuantity(ele) {
    var id = $(ele).attr("data-idbook");
    shoppingCartItems = JSON.parse(sessionStorage['shopping-cart-items'].toString());
    for(var i=0; i<shoppingCartItems.length;i++) { 
        if(shoppingCartItems[i].id == id) {
            shoppingCartItems[i].quantity++;
        }
    }
    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
    displayShopping();
    displayShoppingCartItems();
}
//nút trừ quantity
function minusQuantity(ele) {
    var id = $(ele).attr("data-idbook");
    shoppingCartItems = JSON.parse(sessionStorage['shopping-cart-items'].toString());
    for(var i=0; i<shoppingCartItems.length;i++) { 
        if(shoppingCartItems[i].id == id) {
            if(shoppingCartItems[i].quantity<2) {
                delcartShop(ele);
            } else {
                shoppingCartItems[i].quantity--;
            }
        }
    }
    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
    displayShopping();
    displayShoppingCartItems();
}
var charge = 0;
function DisplayCheckOut() {
    if(sessionStorage['shopping-cart-items'] != null) {  
        shoppingCartItems = JSON.parse(sessionStorage['shopping-cart-items'].toString());
        var total = 0;
        var lengcart = 0;
        $('.page-content-checkout tbody').html("");
        $.each(shoppingCartItems, function(index,item) {  
            var htmlString = "";
            htmlString += '<tr> <td class="col-sm-5"> <div class="media"> <a class="thumbnail pull-left" href="#">';
            htmlString += '<img class="media-object" src="../../images/'+item.image+'" style="width: 70px;"> </a>';
            htmlString += '<div class="media-body"> <h6 class="media-heading ml-3">';
            htmlString += '<a href="#">'+item.name+'</a> </h6> </div> </td> <td class="col-sm-2" style="text-align: center">';
            htmlString += '<div class="cart_quantity_button">'+item.quantity+'</div> </td>';
            htmlString += '<td class="col-sm-3 text-center">'+item.price+'$</td>';
            htmlString += '<td class="col-sm-2 text-center">'+item.quantity*item.price+'$</td> </tr>';
            htmlString += '<form';
            $('.page-content-checkout tbody').append(htmlString);
            total += item.quantity*item.price;
        });
        charge = $('#province>option:first-child').attr("value");
        var html = "";
        html += '<tr> <td colspan="3" class="text-right"> <h5>Tổng</h5> </td> <td class="text-right">';
        html += '<h5>'+total+'$</h5> </td> </tr>';
        html += '<tr> <td colspan="3" class="text-right"> <h5>Phí ship</h5> </td> <td class="text-right">';
        html += '<h5 id="charges">'+charge+'$</h5></td></tr>';
        html += '<tr> <td colspan="3" class="text-right" > <h5>Tổng Phí</h5> </td> <td class="text-right" >';
        html += '<h5 class="d-flex"><input type="text" id="thanhtoan" value="'+(total*0.1+charge*0.1)*10+'" class="border-0 text-right text-body font-weight-bold" disabled="true" >$</h5>';
        html += '</td> </tr>';
        $('.page-content-checkout tbody').append(html);
        
    }
}
$(document).ready(function() {
    
    //kiểm tra có sessionStorage của giỏ hàng chưa
    if(sessionStorage["shopping-cart-items"] != null) {
        //session Storage lưu data dưới dạng cặp giá trị
        shoppingCartItems = JSON.parse(sessionStorage["shopping-cart-items"].toString());// trả về ob json
    }
    displayShoppingCartItems();
    displayShopping();// hiển thị thông tin cart
    DisplayCheckOut();
    var cart = parseFloat($("#thanhtoan").val());

    //ajax phi ship
    $("#province").change(function(event){
        event.preventDefault();
        var id =  $(this).val();
        $.ajax({
            type:'get',
            url:"/Home/ChargeCheckOut/",
            data:{'id':id},
            dataType:"text",//dữ liệu trả về
            success:function(data){
                $("#charges").html(data+'$');
                var da = (data*0.1 + cart*0.1)*10 - charge;
                $("#thanhtoan").val(da);
                
            }
        });
    });
    
});
$(document).ready(function() {  
    $('#submitcart').click(function() {
        for(var i=0;i<shoppingCartItems.length;i++) {
            $.ajax({
                type:'POST',
                url:"/Home/CreateCart/",
                data:{id:shoppingCartItems[i].id,quantity:shoppingCartItems[i].quantity,price:shoppingCartItems[i].price},
                success: function(data) {
                    shoppingCartItems = [];
                    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
                }
            });
        }
    });
})

