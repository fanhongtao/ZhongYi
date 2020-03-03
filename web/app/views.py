import os
from flask import send_from_directory
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

@app.route('/favicon.ico')
def favicon():
    return send_from_directory(os.path.join(app.root_path, 'static'),
                               'favicon.ico', mimetype='image/vnd.microsoft.icon')

@app.route('/zhongyaochaxun')
def zhongyaochaxun():
    return query_named_item_html(const.ZHONGYAO_PATH, 'zhongyaochaxun.html')

@app.route('/ajax/zhongyao')
def ajaxzhongyao():
    return query_named_item(const.ZHONGYAO_PATH, empty_headers)

@app.route('/ajax/zhongyaosuggestion')
def zhongyaosuggestion():
    return query_named_item_suggestion(app.data.zhongyaos)


@app.route('/fangjichaxun')
def fangjichaxun():
    return query_named_item_html(const.FANGJI_WORK_PATH, 'fangjichaxun.html')

@app.route('/ajax/fangji')
def ajaxfangji():
    return query_named_item(const.FANGJI_WORK_PATH, fangji_headers)

@app.route('/ajax/fangjisuggestion')
def fangjisuggestion():
    return query_named_item_suggestion(app.data.fangjis)

def fangji_headers(name):
    headers = []
    if name in app.data.fufang_dict:
        list = app.data.fufang_dict[name]
        for item in list:
            headers.append(("zhufang", item.encode()))
    return headers


def read_file(file_path):
    with open(file_path,'r',encoding='utf-8') as f:
        data = f.read()
    return data


def query_named_item_html(path, template):
    name = request.args.get('name')
    if (name == None):
        return render_template(template)
    file = Path(path + name + ".xml")
    if file.is_file():
        return render_template(template, name=name)
    return render_template(template, error="没有收录：" + name)

def query_named_item(path, header_callback):
    name = request.args.get('name')
    file = Path(path + name + ".xml")
    if file.is_file():
        headers = header_callback(name)
        return read_file(file), 200, headers
    return None

def query_named_item_suggestion(item_list):
    name = request.args.get('name')
    ch = name[0:1]
    byPinyin = False
    if ((ch >= 'a' and ch <= 'z') or (ch >= 'A' and ch <= 'Z')):
        byPinyin = True
    
    suggestions = []
    for item in item_list:
        if item.match(name, byPinyin):
            suggestions.append({'name': item.name, 'py': item.pinyin})
    
    return jsonify(suggestions)


def empty_headers(name):
    return []

