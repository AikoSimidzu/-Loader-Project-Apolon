function err(){
  var i = 0;
  setInterval(function(){
    if (i % 2 == 0)
      $('#wrong').show();
    else 
      $('#wrong').hide();
    i++;
  }, 500);
}