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
//flash sale
var flash = new Date("Feb 5,2021 24:00:00").getTime();
//tổng số giây
var countDown = setInterval(run,1000);
function run() {
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
  document.getElementById('day').innerHTML = days;
  document.getElementById('hours').innerHTML = hours;
  document.getElementById('minutes').innerHTML = minutes;
  document.getElementById('seconds').innerHTML = sec;
}
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
$(document).ready(function(){
  $('.back-to-top').click(function(){
    event.preventDefault();
    $('html,body').animate({scrollTop:0},400);
    return false;
  });
});
//flip to back
$(document).ready(function(){
  var imagesback = document.querySelector('.content-book');
  $('.see-back').click(function(){
    imagesback.classList.toggle('back-view');
  });
});
