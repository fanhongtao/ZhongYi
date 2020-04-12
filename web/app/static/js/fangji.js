$(document).ready(function() {
  initNamedItem("#userinput", "#result", "/ajax/fangjisuggestion", "/ajax/fangji", parseXML)
});

function parseXML(xml, textStatus, xmlHttpRequest) {
  content = getMingCheng(xml);
  content += getZuCheng(xml);
  content += getHtmlElement(xml, "用法");
  content += getHtmlElement(xml, "功用");
  content += getHtmlElement(xml, "主治");
  content += getHtmlElement(xml, "证治机理");
  content += getHtmlElement(xml, "方解");
  content += getHtmlElement(xml, "配伍特点");
  content += getHtmlElement(xml, "辨证要点");
  content += getHtmlElement(xml, "使用注意");
  content += getHtmlElement(xml, "临证加减");
  content += getLinkedItem(xml, "附方");
  content += getJianBie(xml);
  content += getHtmlElement(xml, "医案举例");
  content += getHtmlElement(xml, "方歌");
  content += getLinkedItem(xml, "主方");
  $("#result").html(content);
  $("#result a[href='fang']").each(function() {
    $(this).attr('href', window.location.pathname + "?name=" + $(this).text());
  });
  $("#result a:not([href])").each(function() {
    $(this).attr('href', "/zhongyaochaxun" + "?name=" + $(this).text());
  });
}

function getHtmlElement(xml, name) {
  var ele = $(xml).find(name);
  if (ele.length == 0) {
    content = "";
  } else {
    content = "<h2>" + name + "</h2>";
    content += $(ele[0]).html();
  }
  content += "\n";
  return content;
}

function getMingCheng(xml) {
  var name = $(xml).find("名称")[0];
  var content = '<div class="center"><h1>' + $(name).attr('hz') + " ( " + $(name).attr('py') + " ) </h1>\n" ;
  content += $(name).attr('cc') + "\n";
  
  var bieming = $(xml).find("别名");
  if (bieming.length != 0) {
	content += "<p>别名:&emsp;"
	var count = 0;
	bieming.each(function(){
	  count++;
      if (count > 1) {
        content += ", ";
      }
	  content += $(this).attr('hz') + " (" + $(this).attr('py') + ")";
	})
	content += "</p>\n"
  }
  
  content += "</div>";
  return content;
}

function getZuCheng(xml) {
  var zucheng = $(xml).find("组成")[0];
  var neirong = $(zucheng).find("原文")[0];
  content = "<h2>" + "组成" + "</h2>";
  content += $(neirong).html().replace(/ /g, "&emsp;");
  
  content += '<table class="fangji">';
  content += '<thead><tr><td>编号</td><td>药名</td><td>剂量</td><td>注意事项</td></thead>';
  content += '<tbody>';
  var idx = 0;
  $(zucheng).children("药,方").each(function() {
    zhuyi = ($(this).attr('注') == null) ? "" : $(this).attr('注');
    prefix = (this.tagName == "方") ? '<a href="fang">' : '<a>';
    content += '<tr><td>' + ++idx + '</td><td>'
      + prefix + $(this).attr('名') + '</a></td><td>' 
      + $(this).attr('量') + '</td><td>'
      + zhuyi + '</td></tr>';
  });
  content += '</tbody></table>';
  content += '\n';
  return content;
}

function getJianBie(xml) {
  var jianbie = $(xml).find("鉴别");
  if (jianbie.length == 0) {
    return "";
  }
  
  var content = "<h2>" + "鉴别" + "</h2>";
  jianbie.each(function() {
    var count = 0;
    content += "<font class='bold'>";
    $(this).find("方名").each(function() {
      count++;
      if (count > 1) {
        content += ", ";
      }
      content += getLink($(this).text());
    });
    content += "</font><br/>";
    var neirong = $(this).find("内容")[0];
    content += $(neirong).html();
    content += "<br/>";
  });
  content += "\n";
  return content;
}

function getLinkedItem(xml, name) {
  var ele = $(xml).find(name);
  if (ele.length == 0) {
    return "";
  }
  var count = 0;
  var content = "<h2>" + name + "</h2>";
  $(ele).each(function() {
    count++;
    if (count > 1) {
      content += ", ";
    }
    content += getLink($(this).text());
  });
  content += "\n";
  return content;
}

function getLink(name) {
  return "<a href='" + window.location.pathname + "?name=" + name + "'>" + name + "</a>";
}
