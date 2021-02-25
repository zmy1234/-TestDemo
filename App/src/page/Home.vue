<template>
  <div class="content">
    <el-row :gutter="20">
      <el-col :span="20">
        <el-transfer v-model="RightVulue" 
        :titles="['项目列表', '选择项目']"
        :data="data"></el-transfer>
      </el-col>

    </el-row>
    <br />
    <el-row :gutter="20">
      <el-col :span="12" :offset="6">
        <el-button type="primary" @click="onSubmit">发送邮件{{Email}}</el-button>
      </el-col>
    </el-row>
    <br />
    <!-- <el-row :gutter="20">
      <el-col :span="18">
        <el-input type="textarea" :rows="10" placeholder="发送邮件信息" :disabled="true" v-model="textarea">
        </el-input>
      </el-col>
    </el-row>
    <br /> -->
    <el-row :gutter="20">
      <el-col :span="20">
        <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>发送信息</span>
          </div>
          
          <div  class="text item divScroll" >
            <div v-for="o in selectdata" :key="o.id" >
              <el-row :gutter="20">
                <el-col :span:="20">
                  <a :href="o.repoUrl" target="_blank">{{o.repoTitle}}</a>
                </el-col>
              </el-row>
              <el-row :gutter="20">
                <el-col :span:="20">
                  {{o.repoDesp}}
                </el-col>
              </el-row>
              <br/>
            </div>
          </div>
           
        </el-card>
      </el-col>
    </el-row>
  </div>

</template>

<script>
  import Axios from 'axios'
  export default {
    data() {
      return {
       
        data: [],
        leftlist: [],
        RightVulue: [],
        textarea: "",
        Email: "Zmy@122.com",
        selectdata:[]
      };
    },
    mounted() {
      this.GetLeftTab()
    },
    methods: {
      GetLeftTab() {
        var that=this;
        var leftlist = [];
        var data = [];
        Axios.get('https://localhost:5001/api/Tab')
          .then(function (response) {

            if (response.status == 200) {
              response.data.forEach((item, index) => {
                leftlist.push(item);
                data.push({
                  label: item.repoTitle,
                  key: item.id,
                });

              })
            }
          })
          .catch(function (error) {
            that.$message({
              showClose: true,
              message: '发送失败',
              type: 'error'
            });
          })
        this.leftlist = leftlist;
        this.data = data;
      },
      onSubmit() {
        var that=this;
        var text = "";
        var leftlist = this.leftlist;
        var email = this.Email;
        var selectdata = [];
        if (this.RightVulue.length > 0) {
          this.RightVulue.forEach(function (item, index) {
            text += leftlist[index].repoTitle + "\r\n" + leftlist[index].repoDesp + "\r\n" + leftlist[index].repoUrl + "\r\n\r\n";
            var obj = {
              id: 0,
              repoTitle: leftlist[index].repoTitle,
              repoDesp: leftlist[index].repoDesp,
              repoUrl: leftlist[index].repoUrl,
              sendMail: email,
              sendTime: "2021-02-24T14:47:37.932Z"
            }
            selectdata.push(obj);
          })
        }
        //保存发送内容
        Axios.post("https://localhost:5001/api/Tab/SaveData", selectdata).then(function (response) {
          if(response.status==200&&response.data>0){
            that.$message({
              showClose: true,
              message: '发送成功',
              type: 'success'
            });
            that.textarea = text;
          }else{
            that.$message({
              showClose: true,
              message: '发送失败',
              type: 'error'
            });
            text="";
            selectdata=[]
          }
          console.log(response)
        }).catch(function (error) {
          that.$message({
              showClose: true,
              message: '发送失败',
              type: 'error'
            });
          text="";
          selectdata=[]
        }
        );
        this.selectdata=selectdata;
      }
    }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1,
  h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }

  .content {
    text-align: left;
    background-color: #fff;
    border-radius: 20px;
    width: 800px;
    height: 350px;
    position: absolute;
    left: 50%;
    top: 30%;
    transform: translate(-50%, -50%);
  }
 
  .divScroll{
    height:200px;
        overflow-y:auto;
        padding: 20px;
        OVERFLOW:auto;
  } 
  /*整体部分*/ 
::-webkit-scrollbar
{
	width: 10px;
	height: 10px;
}
/*滑动轨道*/ 
::-webkit-scrollbar-track
{
	border-radius: 0px;
	background: none;
}
/*滑块*/
::-webkit-scrollbar-thumb
{
	border-radius: 5px;
	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.2);
	background-color: rgba(255,255,255,.75)
}
/*滑块效果*/ 
::-webkit-scrollbar-thumb:hover
{
	border-radius: 5px;
	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.2);
	background-color: rgba(85, 85, 85, 0.4);
}
</style>