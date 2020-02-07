from flask import render_template, flash, redirect, request
from app import app

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
    return render_template('zhongyaochaxun.html', zhongyao=name)
