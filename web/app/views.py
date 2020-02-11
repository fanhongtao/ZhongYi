from flask import render_template, flash, redirect, request, send_file
from flask import jsonify
from app import app
from app.const import const
from pathlib import Path

@app.route('/')
@app.route('/index')
def index():
    return render_template("index.html",
        title = 'Home')

@app.route('/zhongyaochaxun')
def zhongyaochaxun():
    name = request.args.get('yao')
    if (name == None):
        return render_template('zhongyaochaxun.html')
    file = Path(const.ZHONGYAO_PATH + name + ".xml")
    if file.is_file():
        return render_template('zhongyaochaxun.html', zhongyao=name)
    return render_template('zhongyaochaxun.html', error="没有收录：" + name)

@app.route('/ajax/zhongyao')
def ajaxzhongyao():
    name = request.args.get('name')
    file = Path(const.ZHONGYAO_PATH + name + ".xml")
    if file.is_file():
        return read_file(file)
    return None

def read_file(file_path):
    with open(file_path,'r',encoding='utf-8') as f:
        data = f.read()
    return data

@app.route('/ajax/zhongyaosuggestion')
def zhongyaosuggestion():
    name = request.args.get('name')
    ch = name[0:1]
    if ((ch >= 'a' and ch <= 'z') or (ch >= 'A' and ch <= 'Z')):
      list = queryByPinyin(name)
    else:
      list = queryByHanzi(name)
    suggestions = [];
    print("list size: " + str(len(list)))
    for zhongyao in list:
        suggestions.append({'name': zhongyao.name, 'py': zhongyao.pinyin});
    return jsonify(suggestions)

def queryByPinyin(name):
  list = []
  for zhongyao in app.data.zhongyaos:
    if zhongyao.matchPinyin(name):
      list.append(zhongyao)
  return list

def queryByHanzi(name):
  list = []
  for zhongyao in app.data.zhongyaos:
    if zhongyao.matchHanzi(name):
      list.append(zhongyao)
  return list
