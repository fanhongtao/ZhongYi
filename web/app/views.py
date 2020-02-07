from flask import render_template, flash, redirect, request
from app import app

@app.route('/')
@app.route('/index')
def index():
    return render_template("index.html",
        title = 'Home')

@app.route('/zhongyaochaxun', methods=['POST', 'GET'])
def zhongyaochaxun():
    if request.method == 'POST':
        name = request.form['yao']
        return render_template('zhongyaochaxun.html', zhongyao=name)
    return render_template("zhongyaochaxun.html")
