$(document).ready(function() {
  initNamedItem("#userinput", "#result", "/ajax/zhongyaosuggestion", "/ajax/zhongyao", parseXML)
});

function parseXML(xml) {
  var name = $(xml).find("名称")[0];
  var content = "<h1>" + $(name).attr('hz') + " ( " + $(name).attr('py') + " )</h1>";
  content += getHtmlElement(xml, "介绍");
  content += getYaoXing(xml);
  content += getHtmlElement(xml, "功效");
  content += getYingYong(xml);
  content += getHtmlElement(xml, "用法用量");
  content += getHtmlElement(xml, "使用注意");
  content += getJianBieYongYao(xml);
  content += getHtmlElement(xml, "其他");
  content += getFuYao(xml);
  $("#result").html(content);
  $("#result a:not([href])").each(function() {
    $(this).attr('href', window.location.pathname + "?name=" + $(this).text());
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
  return content;
}

function addSubElement(xml, name) {
  var ele = $(xml).find(name);
  if (ele.length == 0) {
    content = "";
  } else {
    content = "<font class='bold'>" + name + "</font>: ";
    content += $(ele[0]).text() + "<br/>";
  }
  return content;
}

function getYaoXing(xml) {
  var yaoxing = $(xml).find("药性")[0];
  content = "<h2>" + "药性" + "</h2>";
  content += addSubElement(yaoxing, "气味");
  content += addSubElement(yaoxing, "归经");
  content += addSubElement(yaoxing, "毒性");
  return content;
}

function getYingYong(xml) {
  var yingyong = $(xml).find("应用")[0];
  var content = "<h2>" + "应用" + "</h2>";
  $(yingyong).find("para").each(function() {
    var title = $($(this).find("title")[0]).text();
    content += "<p><font class='bold'>" + title + "</font><br/>";
    content += $($(this).find("text")[0]).html() + "</p>";
  });
  return content;
}

function getJianBieYongYao(xml) {
  var jianbie = $(xml).find("鉴别用药");
  if (jianbie.length == 0) {
    return "";
  }
  
  var content = "<h2>" + "鉴别用药" + "</h2>";
  jianbie.each(function() {
    var count = 0;
    content += "<font class='bold'>";
    $(this).find("鉴药").each(function() {
      count++;
      if (count > 1) {
        content += ", ";
      }
      content += getLink($(this).text());
      $(this).remove();
    });
    content += "</font><br/>";
    content += $(this).text();
    content += "<br/>";
  });
  return content;
}

function getFuYao(xml) {
  var fuyao = $(xml).find("附药");
  if (fuyao.length == 0) {
    return "";
  }
  var count = 0;
  var content = "<h2>" + "附药" + "</h2>";
  $(fuyao).each(function() {
    count++;
    if (count > 1) {
      content += ", ";
    }
    content += getLink($(this).text());
  });
  return content;
}

function getLink(name) {
  return "<a href='" + window.location.pathname + "?name=" + name + "'>" + name + "</a>";
}
