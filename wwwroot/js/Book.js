// slide
$(document).ready(function() {
    var owl = $('.tab-content .owl-carousel');
    owl.owlCarousel({
        items: 5,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 30000,
        autoplayHoverPause: true
      });
});
//flip to back
$(document).ready(function(){
  var imagesback = document.querySelector('.content-book');
  $('.see-back').click(function(){
    imagesback.classList.toggle('back-view');
  });
});
$(document).ready(function() {
  var owl = $('.carousel-author .owl-carousel');
  owl.owlCarousel({
    items:1,
    loop: true,
    margin: 10,
    autoplay: true,
    autoplayTimeout: 10000,
    autoplayHoverPause: true,
    dotsContainer: '#carousel-custom-dots'
  });
  $('.owl-dot').click(function () {
    owl.trigger('to.owl.carousel', [$(this).index(), 300]);
  });
});
//back to top
$(document).scroll(function(){
  var y = $(this).scrollTop();
  if(y>500) {
    $('.back-to-top').css({'opacity':'1','bottom':'2em'});
  } else {
    $('.back-to-top').css({'opacity':'0','bottom':'-3em'});
  }
});

//flash sale

//tổng số giây
var countDown = setInterval(run,1000);
function run() {
  var t = document.getElementsByClassName('flashSale')[0].innerHTML;
  var time = new Date(t);
  var flash = time.getTime();
  // số s đến thời điểm hiện tại
  var now = new Date().getTime();
  // số s còn lại đến flash sale
  var timeRest = flash-now;
  // số ngày còn lại để đến flash sale
  var days = Math.floor(timeRest/(1000*60*60*24));
  // số giờ còn laij
  var hours = Math.floor(timeRest%(1000*60*60*24)/(1000*60*60));
  //số phút
  var minutes = Math.floor(timeRest%(1000*60*60)/(1000*60));
  //số s
  var sec = Math.floor(timeRest%(1000*60)/(1000));
  document.getElementsByClassName('day')[0].innerHTML = days;
  document.getElementsByClassName('hours')[0].innerHTML = hours;
  document.getElementsByClassName('minutes')[0].innerHTML = minutes;
  document.getElementsByClassName('seconds')[0].innerHTML = sec;
}

$(document).ready(function(){
  $('.back-to-top').click(function(){
    event.preventDefault();
    $('html,body').animate({scrollTop:0},400);
    return false;
  });
});
//search ajax
$(document).ready(function() {
  $("#SearchBookHome").keyup(function() {
    var name = $(this).val();
    $.ajax({
      type:'GET',
      url:'/Home/SearchBook/',
      data:{name:name},
      success: function(data) {
        $('.body').html(data.html);
      }
    });
  });
});
// show detail order
// $(document).ready(function() {
//   $('.timetable_sub> tbody> tr').click(function() {
    
//     $('.show-detailOrder .row>div').css("display","block");
//   });
// });
function showdialog(id) {
  document.getElementById(id).show();
}
function closeDialog(id) {
  document.getElementById(id).close();
}
$(document).ready(function() {
    $(".submitComments").click(function() {
        var comments = $("textarea[name='comments']").val();
        var idBook = $("input[name='idBookComments']").val();
        if(comments == "") {
            alert("Vui lòng nhập bình luận!");
        } else {
            $.ajax({
                type:"GET",
                url:"/Home/CreateComment/",
                data:{idBook:idBook,comments:comments},
                success: function(data) {
                    var html = "";
                    var fomattime = data.date_Comment.substr(0,10).split('-').reverse().join('-')+" "+data.date_Comment.substr(11,5);
                    html += '<div class="row"> <div class="col-2"> <div class="icon-commentCus mb-2"><i class="far fa-user"></i></div>';
                    html += '<h5>'+data.customer+'</h5><div>'+fomattime+'</div></div><div class="col-10 text-left">';
                    html += '<div>'+data.content+'</div> <div id="'+data.idComment+'"><div class="row" style="margin:0px"><textarea rows="2" name="reply+'+data.id_Comment+'" style="margin-right: 204px;margin-bottom: 15px;"required></textarea>';
                    html +='<a class="submitReplyComment" data-idComment="'+comment.id_Comment+'">Trả lời</a>';
                    $("#commentCustomer").append(html);
                    
                    $("textarea[name='comments']").val("");
                }
            });
        }
    });
    $(".submitReplyComment").click(function() { 
        var idComment = $(this).attr('data-idComment');
        var y = "reply+"+idComment;
        var reply = $("textarea[name='"+y+"']").val();
        $.ajax({
            type:"GET",
            url:"/Home/CreateReply/",
            data:{content:reply,idComment:idComment},
            success: function(data) {
                var html = "";
                var fomattime = data.date_Reply.substr(0,10).split('-').reverse().join('-')+" "+data.date_Reply.substr(11,5);
                html += '<div class="row Reply-comment"><div class="col-2"><div class="icon-commentCus mb-2"><i class="far fa-user"></i></div>';
                html += '<h5>'+data.nameCustomer+'</h5><div>'+fomattime+'</div></div><div class="col-10 text-left mt-2">';
                html += '<div>'+data.content+'</div></div></div>';
                var x = "#"+idComment;
                $(x).append(html);
                $("textarea[name='reply']").val("");
            }
        });
    });
});