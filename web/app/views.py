from flask import render_template, flash, redirect, request
from app import app
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
    file = Path("../data/zhongyao/" + name + ".xml")
    if file.is_file():
        return render_template('zhongyaochaxun.html', zhongyao=name)
    return render_template('zhongyaochaxun.html', error="没有收录：" + name)

@app.route('/ajax/zhongyao')
def ajaxzhongyao():
    name = request.args.get('name')
    file = Path("../data/zhongyao/" + name + ".xml")
    if file.is_file():
        return read_file(file)
    return None

def read_file(file_path):
    with open(file_path,'r',encoding='utf-8') as f:
        data = f.read()
    return data
