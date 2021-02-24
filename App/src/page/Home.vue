<template>
  <div  class="content">
    <el-row :gutter="20">
      <el-col :span="20">
        <el-transfer v-model="RightVulue" :data="data"></el-transfer>
      </el-col>
      
    </el-row>
    <br/>
    <el-row :gutter="20">
      <el-col :span="8" :offset="7">
        <el-button type="primary" @click="onSubmit" >发送邮件{{Email}}</el-button>
      </el-col>
    </el-row>
    <br/>
    <el-row :gutter="20">
      <el-col :span="20">
        <el-input
        type="textarea"
        :rows="10"
        placeholder="请输入内容"
        v-model="textarea">
      </el-input>
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
        leftlist:[],
        RightVulue: [],
        textarea:"",
        Email:"Zmy@122.com"
      };
    }, 
    mounted () {
      this.GetLeftTab()
    },
     methods: {
        GetLeftTab() {
          var leftlist=[];
          var data=[];
         Axios.get('https://localhost:5001/api/Tab')
         .then(function (response) {
          
          if(response.status==200){
             response.data.forEach((item,index)=>{
              leftlist.push(item);
              data.push({
                label: item.repoTitle,
                key: item.id,
              });

             })
          }
        })
        .catch(function (error) {
           alert('获取列表异常'+error);
        })
        this.leftlist=leftlist;
        this.data=data;
       }, 
      onSubmit() {
        var text="";
        var leftlist=this.leftlist;
        var email=this.Email;
        console.log(this.leftlist);
        var selectdata=[];
        if(this.RightVulue.length>0){
           this.RightVulue.forEach(function(item, index) {
             text+=leftlist[index].repoTitle+"\r\n"+leftlist[index].repoDesp+"\r\n"+leftlist[index].repoUrl+"\r\n\r\n";
             var obj={
               id:0,
              repoTitle:leftlist[index].repoTitle,
              repoDesp:leftlist[index].repoDesp,
              repoUrl:leftlist[index].repoUrl,
              sendMail:email,
              sendTime: "2021-02-24T14:47:37.932Z"
             }
             selectdata.push(obj);
           })
        }
        this.textarea=text;
        //保存发送内容
        Axios.post("https://localhost:5001/api/Tab/SaveData",selectdata).then().catch();
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
  .content{
    text-align: left;
    background-color: #fff;
    border-radius: 20px;
    width: 800px;
    height: 350px;
    position: absolute;
    left: 50%;
    top: 30%;
    transform: translate(-50%,-50%);
  }
</style>