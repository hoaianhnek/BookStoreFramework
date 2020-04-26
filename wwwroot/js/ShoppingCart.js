var shoppingCartItems = [];//mảng phần tử bỏ vào giỏ

$(document).ready(function() {
    //kiểm tra có sessionStorage của giỏ hàng chưa
    if(sessionStorage["shopping-cart-items"] != null) {
        //session Storage lưu data dưới dạng cặp giá trị
        shoppingCartItems = JSON.parse(sessionStorage["shopping-cart-items"].toString());// trả về ob json
    }
    displayShoppingCartItems();// hiển thị thông tin cart
});
//sự kiện click vào button add to cart
$(document).ready(function(){
    $('.add-to-cart>a').click(function(){
        var button = $(this);
        var id = button.attr('id');//id sp
        var name = button.attr('data-name'); //ten sp
        var price = button.attr('data-price');//gia sp
        var quantity = 1;
        var image = button.attr('data-image');
        
        var items = {
            id: id,
            image: image,
            name: name,
            price: price,
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
        alert("records add successfully!");
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
        html += "<strong>Subtotal:</strong>"
        html += "<span>$"+total+"</span>";
        html += "</div>";
        html += "<div class='view-minicart'> <a href='#'>View Cart</a> </div>";
        html += "</div>";
        $("#cartne").append(html);
        $("#lengcart").html(lengcart);
    }
}

function delCart() {
    var id =$('#del-cart').attr('data-idbook');
    for(var i=0;i<shoppingCartItems.length;i++) {
        if(shoppingCartItems[i].id == id) {
            alert("Bạn đã xóa thành công!")
            shoppingCartItems.splice(i,1);
        }
    }
    sessionStorage["shopping-cart-items"] = JSON.stringify(shoppingCartItems);
    displayShoppingCartItems();
}