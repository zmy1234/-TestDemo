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
        <el-button type="primary" @click="onSubmit" >发送邮件</el-button>
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
  export default {
    data() {
      const generateData = _ => {
        const data = [];
        const cities = ['上海', '北京', '广州', '深圳', '南京', '西安', '成都'];
        const pinyin = ['shanghai', 'beijing', 'guangzhou', 'shenzhen', 'nanjing', 'xian', 'chengdu'];
        cities.forEach((city, index) => {
          data.push({
            label: city,
            key: index,
            pinyin: pinyin[index]
          });
        });
        return data;
      };
      return {
        cities : ['上海', '北京', '广州', '深圳', '南京', '西安', '成都'],
        pinyin : ['shanghai', 'beijing', 'guangzhou', 'shenzhen', 'nanjing', 'xian', 'chengdu'],
        data: generateData(),
        RightVulue: [],
        textarea:""
      };
    }, 
     methods: {
      onSubmit() {
        console.log(this.RightVulue);
        console.log(this.cities);
        var cities=this.cities;
        var text="";
        if(this.RightVulue.length>0){
           this.RightVulue.forEach(function(item, index) {
             text+=cities[index]+"\r\n";
           })
        }
        this.textarea=text
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