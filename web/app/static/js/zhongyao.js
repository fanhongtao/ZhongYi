$(document).ready(function() {
  displayZhongYao();
});

function displayZhongYao() {
  var zhongyao =  $("#yaomin").val().trim()
  if (zhongyao.length == 0) {
    return;
  }
  $.ajax({
    type : "GET",
    contentType: "application/json;charset=UTF-8",
    url : "/ajax/zhongyao",
    data:{ "name":zhongyao },
    dataType:"xml",
    success: function (msg) {
      parseXML(msg);
    },
    error:function () {
      $("#result").html("查询中药失败： " + zhongyao)
    }
  });
}

function parseXML(xml) {
  var name = $(xml).find("名称");
  var str = $(name[0]).attr('hz');
  var content = "<h1>" + str + "</h1>"
  content += $(name[0]).attr('py');
  $("#result").html(content)
}
