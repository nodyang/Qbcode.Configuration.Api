<template>
    <div>
        <div class="page-wrap">
            <div class="from-wrap">
                <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="100">
                    <FormItem label="Log">
                        <Row>
                            
                            <Col span="8">
                                <FormItem label="LogLevel" prop="LogLevel" :label-width="100">
                                    <Select v-model="formValidate.LogLevel" style="width:80px">
                                        <Option v-for="(item,index) in formValidate.LogTypes" :key="index" :value="item">{{item}}</Option>
                                    </Select>
                                </FormItem>
                            </Col>
                            <Col span="8">
                                <FormItem label="LogCacheSize" prop="LogCacheSize" :label-width="100">
                                    <InputNumber :max="100000" :min="1" v-model="formValidate.LogCacheSize"></InputNumber>
                                </FormItem>
                            </Col>
                            <Col span="8">
                                <FormItem label="" prop="LogConsole" :label-width="0">
                                    <Checkbox v-model="formValidate.LogConsole">LogConsole</Checkbox>
                                </FormItem> 
                            </Col>
                        </Row>
                    </FormItem>
                    <FormItem label="Buffer">
                        <Row>
                            <Col span="8">
                                 <FormItem label="BufferSize" prop="BufferSize" :label-width="100">
                                    <InputNumber :max="100000" :min="1" v-model="formValidate.LogCacheSize"></InputNumber>
                                </FormItem>
                            </Col>
                            <Col span="8">
                                <FormItem label="BufferPoolSize" prop="BufferPoolSize" :label-width="100">
                                    <InputNumber :max="100000" :min="1" v-model="formValidate.BufferPoolSize"></InputNumber>
                                </FormItem>
                            </Col>
                        </Row>
                    </FormItem>
                    <FormItem label="Max">
                        <Row>
                            <Col span="8">
                                <FormItem label="Connection" prop="MaxConnections" :label-width="100">
                                    <InputNumber :max="1000000" :min="1" v-model="formValidate.MaxConnections"></InputNumber>
                                </FormItem>
                            </Col>
                            <Col span="8">
                                <FormItem label="WaitQueue" prop="MaxWaitQueue" :label-width="100">
                                    <InputNumber :max="100000" :min="1" v-model="formValidate.MaxWaitQueue"></InputNumber>
                                </FormItem>
                            </Col>
                            <Col span="8">
                                <FormItem label="BodyLength" prop="MaxBodyLength" :label-width="100">
                                    <InputNumber :max="100000" :min="1" v-model="formValidate.MaxBodyLength"></InputNumber>
                                </FormItem>
                            </Col>
                        </Row>
                    </FormItem>
                    <FormItem label="ZIP">
                        <Row>
                            <Col span="16">
                                <FormItem label="NoGzipFiles" prop="NoGzipFiles" :label-width="100">
                                    <Input v-model="formValidate.NoGzipFiles" type="textarea" style="width:280px; resize:none;" :autosize="{minRows: 2,maxRows: 2}" placeholder="Enter something..."></Input>
                                </FormItem>
                            </Col>
                            <Col span="6">
                                <FormItem label="" prop="AutoGzip">
                                    <Checkbox v-model="formValidate.AutoGzip">AutoGzip</Checkbox>
                                </FormItem> 
                            </Col>
                        </Row>
                    </FormItem>
                    <FormItem label="" prop="OutputServerAddress">
                        <Checkbox v-model="formValidate.OutputServerAddress">OutputServerAddress</Checkbox>
                    </FormItem> 
                    <FormItem label="" prop="StatisticsEnabled">
                        <Checkbox v-model="formValidate.StatisticsEnabled">StatisticsEnabled</Checkbox>
                    </FormItem> 
                    <FormItem label="StatisticsExts" prop="StatisticsExts">
                        <Input v-model="formValidate.StatisticsExts" type="textarea" :autosize="{minRows: 2,maxRows: 5}" placeholder="Enter something..."></Input>
                    </FormItem>
                    <FormItem>
                        <Button type="primary" :loading="loading" @click="handleSubmit('formValidate')">保存一下</Button>
                        <Button @click="handleReset('formValidate')" style="margin-left: 8px">重置</Button>
                    </FormItem>
                </Form>
            </div>
        </div>
    </div>
</template>
<script>
import {get,post} from '../request/index'
export default {
    name:'setting',
    components: {},
    data () {
        return {
            formValidate:{
                "LogTypes":["All","Trace","Debug","Info","Warring","Error","Fatal","Off"]
                ,"LogLevel":"All"
                ,"LogCacheSize":1000
                ,"LogConsole":true
                ,"AutoGzip":false
                ,"NoGzipFiles":"jpg;jpeg;png;gif;png;ico;zip;rar"
                ,"BufferPoolSize":10
                ,"BufferSize":8192
                ,"MaxConnections":100000
                ,"MaxWaitQueue":100000
                ,"MaxBodyLength":2097152
                ,"OutputServerAddress":false
                ,"StatisticsEnabled":true
                ,"StatisticsExts":""
            },
            ruleValidate:{

            },
            loading:false
        }
    },
    mounted(){
        this.loadData();
    },
    beforeDestroy(){
    },
    methods:{
        loadData(){
            this.loading = true;
            get('GetSetting').then((res)=>{
                this.loading = false;
                this.formValidate =  JSON.parse(JSON.stringify(res.data.Data));
            }).catch(()=>{
                this.$Message.error('加载数据失败!');
            })
        },
        handleSubmit (name) {
            this.$refs[name].validate((valid) => {
                if (!valid) {
                    this.$Message.error('Fail!');
                    return false;
                }
                this.loading = true;
                post('SetSetting',this.formValidate).then((res)=>{
                    this.loading = false;
                    this.$Message.success('保存成功!');
                }).catch(()=>{
                    this.loading = false;
                    this.$Message.error('保存失败!');
                })
            })
        },
        handleReset (name) {
            this.$refs[name].resetFields();
        }
    }
}
</script>
<style scoped>
.from-wrap{padding: 50px;width: 800px;margin: 0 auto;}
</style>