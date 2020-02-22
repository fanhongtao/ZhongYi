function initNamedItem(inputbox, resultbox, suggestUrl, queryUrl, resultHandler) {
  $(inputbox).autocomplete({
    source: function(request, response) {
      $.ajax({
        contentType:"application/json;charset=UTF-8",
        url:suggestUrl,
        data:{ "name":request.term },
        dataType:"json",
        success:function (msg) {
          response( $.map( msg, function( item ) {
            return {label: item.name  + " ( " + item.py + " )", value: item.name }
          }));
        },
      });
    },
    select: function(event, ui) {
      queryNamedObject(ui.item.value, resultbox, queryUrl, resultHandler);
    },
  });
  
  var inputStr =  $(inputbox).val().trim()
  if (inputStr.length != 0) {
    queryNamedObject(inputStr, resultbox, queryUrl, resultHandler);
  }
}

function queryNamedObject(inputStr, resultbox, queryUrl, resultHandler) {
  $.ajax({
    type : "GET",
    contentType: "application/json;charset=UTF-8",
    url : queryUrl,
    data:{ "name":inputStr },
    dataType:"xml",
    success: resultHandler,
    error:function () {
      $(resultbox).html("查询失败： " + inputStr)
    }
  });
}
